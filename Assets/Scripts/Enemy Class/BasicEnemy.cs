using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    private int basicEnemySpeed = 2;

    protected override void Update()
    {
        base.Update();
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection * basicEnemySpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
}
