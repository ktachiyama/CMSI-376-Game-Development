using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yummies : Actor
{
    public void yayImRetrieved()
    {
        if (canRespawn)
        {
            Debug.Log("I can respawn");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("being destroyed");
            Destroy(gameObject);
        }
    }
}
