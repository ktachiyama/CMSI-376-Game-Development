using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowShot : MonoBehaviour
{
    private float speed = 30f;
    private Rigidbody2D rb;
    private float shotTime = 25f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        shotTime--;
        if(shotTime < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("enemy"))
        {
            other.GetComponent<Enemy>().Die();
            Destroy(gameObject);
        }
        else if(other.CompareTag("ground") ||other.CompareTag("block") ||
            other.CompareTag("wall"))
        {
            Destroy(gameObject);
        }

    }
}
