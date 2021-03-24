using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 1f; //variable representing the speed
    public bool change = false; //determines direction to go in
    public float timing; //determines when to switch directions

    public Vector3 pos
    {
        //The get accessor
        get
        {
            return (this.transform.position);
        }
        //The set accessor
        set
        {
            this.transform.position = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timing += Time.deltaTime;
        if (timing > 3 && change == false)  //makes player change direction
        {
            change = true;
            timing = 0;
        }
        else if (timing > 3 && change == true) //makes player change direction
        {
            change = false;
            timing = 0;
        }

        //Determines which way to move
        if (change == false)
        {
            MoveNegative();
        }
        else
        {
            MovePositive();
        }
    }

    //Makes the enemy move downward
    public virtual void MoveNegative()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    //Makes the enemy move upward
    public virtual void MovePositive()
    {
        Vector3 tempPos = pos;
        tempPos.y += speed * Time.deltaTime;
        pos = tempPos;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Sword") || (collision.gameObject.tag == "Rifle")) //If enemy is hit by player with weapon
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player") //If enemy hits player when he is in danger
        {

            HeroController.health--;    //subtract health
            print("Health " + HeroController.health);
        }
    }
}