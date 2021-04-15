using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor
{
    private GameObject bunnyGO;
    public int XMoveDirection = -1;
    public bool facingRight = false;

    void Awake()
    {
        bunnyGO = GameObject.Find("Bunny");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
            if (gameObject.transform.position.y < GameManager.DEATH_HEIGHT)
        {
            Die();
        }
    }

    //void OnBecameVisible()
    //{
    //    enabled = true;
    //}

    //void OnBecameInvisible()
    //{
    //    enabled = false;
    //}

    public void Die()
    {
        gameObject.SetActive(false);
    }
    public void Live()
    {
        gameObject.SetActive(true);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "block" || other.gameObject.tag == "wall")
        {
            Flip();
        }else if (other.gameObject.tag == "bunny")
        {
            //if(other.transform.position.x > gameObject.transform.position.x)
            Die();
           
            GameManager.Instance.Ouch();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        XMoveDirection *= -1;
        transform.localScale = localScale;
    }
}
