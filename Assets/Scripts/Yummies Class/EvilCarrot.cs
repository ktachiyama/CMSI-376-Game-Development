using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCarrot : Yummies
{
    void Awake()
    {
        canRespawn = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bunny")
        {
            yayImRetrieved();
            GameManager.Instance.Ouch();
        }
    }
}
