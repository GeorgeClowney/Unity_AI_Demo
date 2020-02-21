using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

//This script adds keyboard controls for player movement
public class FPSInput : MonoBehaviour
{
    [SerializeField] GameManager gm;
    //Varibles that control the players speed and how they are effected by gravity
    public float speed = 6.0f;
    public bool isTeleporting = false;
    public float gravity = -6.8f;

    //Variable for referencng the CharacterController line 45
    private CharacterController _charController;

    void Start()
    {
        //Acess the CharacterController attached to this gameObject
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (gm.gamePaused == false)
        {
            //"Horizontal" and "Vertical" are indirect names for the WASD keys
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;

            //Update the players location 
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);

            //Limit diagonal movement to the same speed as movement along an axis
            movement = Vector3.ClampMagnitude(movement, speed);

            //Dosn't let the player "fly"
            movement.y = gravity;

            //Movement goes through deltaTime to unlock the movement from the framerate
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);

            //Tell the CharacterController to move to the new vector
            if (!isTeleporting)
            {
                _charController.Move(movement);
            }
        }
    }
}
