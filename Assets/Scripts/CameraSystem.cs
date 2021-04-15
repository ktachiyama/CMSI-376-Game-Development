using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private GameObject player;
    private float xMin;
    private float xMax;
    private float yMin = 0;
    private float yMax = 30;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("bunny");

        xMin = GameObject.Find("sceneEdgeLeft").transform.position.x + (float)16.5;
        xMax = GameObject.Find("sceneEdgeRight").transform.position.x - (float)16.5;

    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
