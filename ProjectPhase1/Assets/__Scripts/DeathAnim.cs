﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Basic code run death animation.
public class DeathAnim : MonoBehaviour
{

    public HeroController HeroController;
    public GameObject TaskBar, DeathScreen;

    // Update is called once per frame
    void Update()
    {
        if (HeroController.health <= 0)//Hero dies
        {   //Spin
            transform.Rotate(new Vector3(0f, 0f, 1000f) * Time.deltaTime);
            //Shrink
            float newXScale = transform.localScale.x * 0.99f;
            float newYScale = transform.localScale.y * 0.99f;
            float newZScale = transform.localScale.z * 0.99f;

            if (newXScale > 0 && newYScale > 0 && newZScale > 0)
                transform.localScale = new Vector3(newXScale, newYScale, newZScale);
            //Make death screen visible
            DeathScreen.SetActive(true);
            TaskBar.SetActive(false);
            
        }
    }
}
