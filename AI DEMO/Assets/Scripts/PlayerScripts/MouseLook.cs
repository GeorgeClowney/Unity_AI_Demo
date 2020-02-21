using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script gives the mouse its look functions
public class MouseLook : MonoBehaviour
{
    [SerializeField] GameManager gm;
    //enum data structure to associate names with settings
    public enum RotationAxes
    {
        MouseXAndY = 0,
        //Set the player to MouseX
        MouseX = 1,
        //Set the Camera to MouseY
        MouseY = 2
    }
    //The public variables set in the Inspector
    public RotationAxes axes = RotationAxes.MouseXAndY;

    //Set the speed of mouse rotation
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    //Limit how much you can look up and down
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    //variable for the current vertical angle
    private float _rotationX = 0;

    void Start()
    {
        //Disallow physics rotation on the player
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    void Update()
    {

        if (gm.gamePaused == false)
        {
            //Horizontal rotation
            if (axes == RotationAxes.MouseX)
            {
                //GetAxis is used to get mouse input
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            }
            //Vertical rotation
            else if (axes == RotationAxes.MouseY)
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;

                //Clamp the vertical angle between minimum and maximum limits
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                //Keep the same horizontal angle
                float rotationY = transform.localEulerAngles.y;

                //Create a new vector from the stored rotation values
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
            //Both horizontal and vertical rotation
            else
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                //Delta/deltaTime is used so speed is not locked to framerate
                float delta = Input.GetAxis("Mouse X") * sensitivityHor;

                //Increment the rotation angle by delta
                float rotationY = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
    }
}
