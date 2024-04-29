using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float close = 5.0f;
    public float speed = 3.0f;
  
    // Update is called once per frame
    void Update()
    {
        Vector3 chaseDir = player.transform.position - transform.position;
        float chaseDist = chaseDir.magnitude;
        chaseDir.Normalize();
        if(chaseDist <= close)
        {
            //Chase the player
            GetComponent<Rigidbody2D>().velocity = chaseDir * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        GetComponent<Animator>().SetFloat("xImput", chaseDir.x);
        GetComponent<Animator>().SetFloat("yImput", chaseDir.y);
    }
}
