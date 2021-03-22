using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : EnemyControl
{
    public override void MoveNegative()
    {
        Vector3 tempPos = pos;
        tempPos.x -= speed * Time.deltaTime;
        pos = tempPos;
    }
    public override void MovePositive()
    {
        Vector3 tempPos = pos;
        tempPos.x += speed * Time.deltaTime;
        pos = tempPos;
    }
}

