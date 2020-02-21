using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is all about raycasting
//It allows the player to shoot bullets in a straight line
//The script is attached to the Camera which is a child of the Player Prefab
public class RayShooter : MonoBehaviour {
    private Camera _camera;
    void Start()
    {
        //Access the camera component that is attached to the same GameObject
        _camera = GetComponent<Camera>();

        //Locking the cursor and hiding helps the player aim
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth/2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect (posX, posY, size, size), "+");
    }
  
    void Update()
    {
        //is called when the player presses the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            
            //Finding the vector that is the middlepoint of the screen
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            //Creates the ray on that point
            Ray ray = _camera.ScreenPointToRay(point);
        
            //Look for info on if the raycast hits anything
            RaycastHit hit;
            
            //What to do based on what the raycast hits
            if (Physics.Raycast(ray, out hit))
            {

                //if the raycast hits a GameObject with the ReactiveTarget script call ReactToHit()
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    //If the raycast hits a object that is not a ReactiveTarget then run(SphereIndicator)
                    StartCoroutine(SphereIndicator(hit.point));                    
                }
            }
        }
    }

    //SphereIndicator is a function that places a basic sphare into the world at the location you fire at 
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        //yeid return is the best way to put a "delay" your function
        //This one waits for one secend then destorys the sphere
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
