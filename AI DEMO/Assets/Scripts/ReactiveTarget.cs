using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ReactiveTarget is a script that makes a GameObject "killable"
//It does this by detecting hits by the raytrace made from the RayShooter script
public class ReactiveTarget : MonoBehaviour
{

    //ReactToHit() is called in the RayShooter script once a GameObject with the Reactive Target script has been hit
    public void ReactToHit()
    {
        //Stops the BasicWanderingAI script 
        //Enemys would still walk around after they got shot if SetDead wasnt set to true
        BasicAI behavior = GetComponent<BasicAI>();
        if (behavior != null)
        {
           // behavior.SetDead(true);
        }
        //After the GameObject is hit it can die
            StartCoroutine(Die());
       
    }
    //Die() is a corutine that topples the GameObject over, waits for 1.5 secends and then removes the GameObeject from the curEnemy list in the SceneController script
    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f); 
        Destroy(this.gameObject);   
        
        //SceneController will only spwan 5 enemys at a given point
        //Once a enemay dies the current amount is reduced by 1 and a new enemy is spawned
       // SceneController _SceneController = FindObjectOfType<SceneController>();
      //  _SceneController._curEnemy--;
    }
}

