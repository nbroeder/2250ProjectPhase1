using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 1f; //variable representing the speed
    public bool change = false;
    public float timing;
    public int health = 200;

    public GameObject hero;
    
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
        if (timing > 3 && change == false)
        {
            change = true;
            timing = 0;
        }
        else if (timing > 3 && change == true)
        {
            change = false;
            timing = 0;
        }

        if (change == false)
        {
            MoveNegative();
        }
        else
        {
            MovePositive();
        }

        if (health == 0)
        {
            Destroy(hero);
        }
    }

    public virtual void MoveNegative()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
    public virtual void MovePositive()
    {
        Vector3 tempPos = pos;
        tempPos.y += speed * Time.deltaTime;
        pos = tempPos;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Sword") || (collision.gameObject.tag=="Rifle"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Danger")
        {
            health -=1;
        }
    }

    private IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);


        }
    }
