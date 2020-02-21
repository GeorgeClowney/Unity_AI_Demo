using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BasicAI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public Transform Player;
    public Transform Spawnpoint;
    int m_CurrentWaypointIndex;
    public int StateMachine;
    public bool speedUp;
    public bool speedDown;
    public bool speedReset;
    public Animator IanAniCon;
    // Start is called before the first frame update

    void Start()
    {
        IanAniCon = GetComponent<Animator>();
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        //Call the int from the animation controller and match it to this StateMachine
        IanAniCon.SetInteger("AniState", StateMachine);
        if (speedUp)
        {
            navMeshAgent.speed += 5;
            speedUp = false;
        }
        if (StateMachine == 0)
        {
            navMeshAgent.speed = 0;
        }
        if (StateMachine == 1)
        {
   
            if (speedReset)
            {
                navMeshAgent.speed = 5;
                speedReset = false;
            }
            WaypointPatrol();
        }
        if (StateMachine == 2)
        {
            RunAtPlayer();
            navMeshAgent.speed = 10;
        }

    }

    public void startPatrol() {
        StateMachine = 1;
        print(StateMachine);
        speedReset = true;
         navMeshAgent.SetDestination(waypoints[0].position);
    }


    public void chasePlayer()
    {
        StateMachine = 2;
        print(StateMachine);
        speedReset = true;
    }

    public void sonic()
    {
        speedUp = true;
    }

    private void WaypointPatrol()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            navMeshAgent.ResetPath();        
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
    private void RunAtPlayer()
    {
        navMeshAgent.ResetPath();
        navMeshAgent.destination = Player.localPosition;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player") 
        {
            this.transform.position = Spawnpoint.transform.position;
            StateMachine = 0;

        }

    }
   
}
