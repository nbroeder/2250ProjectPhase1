﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFollow : MonoBehaviour
{
    [Header("Set in Inspector: EnemyFollow")]
    public float speed = 1f; //variable representing the speed

    public Text healthText;
    public Text xpText;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HeroController.level<=2) // Move only if the satellite has not been found for second level (otherwise they keep coming after game is won!)
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Sword") || (collision.gameObject.tag == "Rifle")) //If enemy is hit by player with weapon
        {
            Destroy(this.gameObject);   //destroy enemy
            HeroController.xp += 3;     //gain xp
            xpText.text = "XP: " + HeroController.xp;   //update text
        }
        if (collision.gameObject.tag == "Player") //If enemy hits player when he is in danger
        {
            Destroy(this.gameObject);   //destroy enemy
            HeroController.health-=3;    //subtract health
            healthText.text = "Health: " + HeroController.health;   //update text
        }
    }
}
