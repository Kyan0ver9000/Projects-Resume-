using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class BossAI : MonoBehaviour
{
    public Transform target;
    public float activationDistance = 20f;
    public float nextWaypointDistance = 3f;
    public Transform[] corners;
    public float waitTime = 2.0f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
    public Transform currentTarget;
    int behaviorCount = 0;
    [Header("Charge Settings")]
    public float chargeSpeed = 10f;
    public float chargeDuration = 2;
    [Header("Shoot Settings")]
    public GameObject bulletPrefab;
    public int bulletCount = 5;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2.0f;
    public float bulletDelay = 0.5f;
    float startSpeed;
    Transform placeholder;
    bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        startSpeed = GetComponent<AIPath>().maxSpeed;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        seeker.StartPath(rb.position, currentTarget.position, OnPathComplete);
        //StartCoroutine(ChooseBehavior());
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
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
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * Time.deltaTime;
        float xInput = direction.x;
        float yInput = direction.y;
        GetComponent<Animator>().SetFloat("xInput", xInput);
        GetComponent<Animator>().SetFloat("yInput", yInput);
        if (!activated)
        {
            Vector3 playerDir = target.position - transform.position;
            if (playerDir.magnitude <= activationDistance)
            {
                activated = true;
                StartCoroutine(ChooseBehavior());
            }
        }
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
        }
        else
        {
            reachedEndOfPath = false;
        }


    }
    private IEnumerator ChooseBehavior()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            behaviorCount++;
            if (behaviorCount % 4 == 0)
            {
                StartCoroutine(ShootPlayer());
            }
            //Random r = new Random();
            int num = Random.Range(0, corners.Length + 1);
            if (num == corners.Length)
            {
                StartCoroutine(ChargePlayer());
            }
            else
            {
                float dist = Vector2.Distance(transform.position, corners[num].position);
                if (dist <= 1)
                {
                    num++;
                    num = num % corners.Length;
                }
                currentTarget = corners[num];
            }
        }
    }
    private IEnumerator ChargePlayer()
    {
        Debug.Log("CHARGE");
        currentTarget = target;
        GetComponent<AIPath>().maxSpeed = chargeSpeed;
        yield return new WaitForSeconds(chargeDuration);
        GetComponent<AIPath>().maxSpeed = startSpeed;
    }
    private IEnumerator ShootPlayer()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Debug.Log("foo");
            Vector3 shootDir = target.position - transform.position;
            GameObject bullet = Instantiate(bulletPrefab,
                    transform.position, Quaternion.identity);
            Debug.Log(shootDir);
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            Destroy(bullet, bulletLifetime);
            yield return new WaitForSeconds(bulletDelay);
        }
    }
}