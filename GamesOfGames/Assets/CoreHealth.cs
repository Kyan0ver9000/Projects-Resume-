using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreHealth : MonoBehaviour
{  private Animator coreAnimator;
   public GameObject core;
    public int health = 50;
    private void Awake()
    {
        
        coreAnimator = core.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 

     
     
        if (collision.gameObject.tag == "PlayerBullet")
        {
            health--;
            if (health <= 0)
            {
                coreAnimator.SetTrigger("Explosion");
                Level_Changer fn = GameObject.FindObjectOfType(typeof(Level_Changer)) as Level_Changer;
                fn.FadeToNextLevel();
               
            }
        }
    }
}
