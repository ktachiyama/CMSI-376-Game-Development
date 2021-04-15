using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthyCarrot : Yummies
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bunny")
        {
            yayImRetrieved();
            GameManager.Instance.gainLife();
        }
    }
}
