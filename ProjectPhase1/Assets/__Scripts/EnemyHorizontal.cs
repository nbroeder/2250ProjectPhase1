using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : EnemyControl
{
    //Makes the enemy move to the left
    public override void MoveNegative()
    {
        Vector3 tempPos = pos;
        tempPos.x -= speed * Time.deltaTime;
        pos = tempPos;
    }

    //Makes the enemy move to the right
    public override void MovePositive()
    {
        Vector3 tempPos = pos;
        tempPos.x += speed * Time.deltaTime;
        pos = tempPos;
    }
}

