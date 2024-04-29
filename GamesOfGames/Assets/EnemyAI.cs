using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAI : MonoBehaviour
{
    
    [Header("Chase Settings")]
    public Transform target;
    public float chaseSpeed = 200f;
    public float chaseTriggerDistance = 10.0f;

    [Header("Patrol Settings")]
    public float paceSpeed = 100f;
    public float nextWaypointDistance = 3f;
    public Transform home;
    public Transform patrolSpot;
    public Transform currentTarget;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        currentTarget = home;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    private void Update()
    {
        
       
    }
    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, currentTarget.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            
        }
        else
        {
            reachedEndOfPath = false;
        }
        ChooseTarget();
        ChaseTarget();
    }
    void ChooseTarget()
    {
  

        float distToPlayer = ((Vector2)target.position - rb.position).magnitude;
        if (distToPlayer <= chaseTriggerDistance)
        {
            currentTarget = target;
            //UpdatePath();
        }
        if(currentTarget == target && distToPlayer > chaseTriggerDistance)
        {
            currentTarget = home;
        }
        if (currentTarget == home && reachedEndOfPath)
        {
            currentTarget = patrolSpot;
            //UpdatePath();
        }
        else if (currentTarget == patrolSpot && reachedEndOfPath)
        {
            currentTarget = home;
           // UpdatePath();

        }
    }
    void ChaseTarget()
    { 

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * Time.deltaTime;
        float xImput = direction.x;
        float yImput = direction.y;
        GetComponent<Animator>().SetFloat("xImput", xImput);
        GetComponent<Animator>().SetFloat("yImput", yImput);
        if (currentTarget == target)
        {
            force *= chaseSpeed;
       
        }
        else
        {
            force *= paceSpeed;

           
        }
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
