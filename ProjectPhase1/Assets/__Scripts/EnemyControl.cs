using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 1f; //variable representing the speed
    public bool change = false;
    public float wait = 5;
    public float timing;
    
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }
}
