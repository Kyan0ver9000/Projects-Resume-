using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //the amount of speed mulitplied by the movement direction
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Check for vertical/horizontal imput
       
        //Display x imput in log
        // Debug.Log(xImput);
        //creates a vector2 using ximput and yImput//then finds the rigid body component's velocity making it equal to the movement Direction * speed.
        float xImput = Input.GetAxis("Horizontal");
        float yImput = Input.GetAxis("Vertical"); 
        GetComponent<Animator>().SetFloat("xImput", xImput);
        GetComponent<Animator>().SetFloat("yImput", yImput);
        Vector2 moveDir = new Vector2(xImput, yImput);
        GetComponent<Rigidbody2D>().velocity = moveDir * speed;

    }

}
