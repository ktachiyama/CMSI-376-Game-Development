using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Actor : MonoBehaviour
{
    private float startingXPos;
    private float startingYPos;
    protected bool isAlive;
    public bool canRespawn = true;
    private int count = 0;

    public Actor()
    {
        //GameManager.Instance.addActor(this);
        //Debug.Log("actor const called");       
    }

    void Awake()
    {
        startingXPos = gameObject.transform.position.x;
        startingYPos = gameObject.transform.position.y;
        isAlive = true;
        GameManager.Instance.addActor(this);
    }

    //public void getIsAlive()
    //{
    //    return isAlive;
    //}


    public float GetDistanceBetween(GameObject actor1, GameObject actor2)
    {
        Debug.Log("finding distance");
        float x_distance = actor1.transform.position.x - actor2.transform.position.x;
        float y_distance = actor1.transform.position.y - actor2.transform.position.y;
        return Mathf.Sqrt((x_distance * x_distance) + (y_distance * y_distance));
    }

    public void ResetPosition()
    {
        Debug.Log("resetPosition called");
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector2(startingXPos, startingYPos);
    }
}
