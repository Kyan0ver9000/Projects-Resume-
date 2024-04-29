using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{ 


    private void OnCollisionStay2D(Collision2D collision)
    {
        string otherName = collision.gameObject.name;
        if (otherName == "Player" && Input.GetKey(KeyCode.E))
        {
       
          
             Destroy(this.gameObject);
                
           

        }
       
    }

}
