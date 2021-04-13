using System.Collections;    //import statements
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour //class to keep hero within the world map
{

    public float maxX, minX, maxY, minY;

    // Update is called once per frame
    void Update()
    {
        if (transform != null)
            //clamp the hero's dimensions to the x,y and z boundaries of the map
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }
}
