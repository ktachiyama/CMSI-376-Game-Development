using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FollowingEnemy : Enemy
{
    Path path;
    int currentWaypoint;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    public Transform bunnyTf;
    public float followEnemySpeed = 400f;
    public float nextWaypointDistance = 3f;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, bunnyTf.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    protected override void Update()
    {
        base.Update();

        if (path == null)
        {
            return;
        }
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * followEnemySpeed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        

    }













    //public AIPath aiPath;
    //Vector2 localScale;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    localScale = gameObject.transform.localScale;
    //}

    //// Update is called once per frame
    //protected override void Update()
    //{
    //    if (aiPath.desiredVelocity.x >= 0.01f)
    //    {
    //        //transform.localScale = new Vector3(-1f, 1f, 1f);
    //        localScale.x *= -1;

    //    }
    //    else if (aiPath.desiredVelocity.x <= 0.01f)
    //    {
    //        //transform.localScale = new Vector3(1f, 1f, 1f);
    //        localScale.x *= -1;


    //    }
    //}
}
