using System.Collections;         //import statements
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour   //class to make the camera follow the hero
{
    public Transform target;      //set a target for the camera

    public float cameraDistance = 40.0f;  //set the distance between the hero and the camera

    //awake is called before the game starts
    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);  //get the size of the camera
    }

    //update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); //set the position of the camera to follow the targets x y and z coordinates
    }
}
