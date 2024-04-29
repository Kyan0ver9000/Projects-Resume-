using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        string otherName = collision.gameObject.name;
        if (otherName == "DoorIntoOffice" && Input.GetKeyDown(KeyCode.E))
        {

            Level_Changer fn = GameObject.FindObjectOfType(typeof(Level_Changer)) as Level_Changer;
            fn.FadeToNextLevel();

        }
        if (otherName == "ExitDoor" && Input.GetKeyDown(KeyCode.E))
        {

            Level_Changer fn = GameObject.FindObjectOfType(typeof(Level_Changer)) as Level_Changer;
            fn.FadeToNextLevel();

        }
        if (otherName == "LadderToBasement" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("foo");
            Level_Changer fn = GameObject.FindObjectOfType(typeof(Level_Changer)) as Level_Changer;
            fn.FadeToNextLevel();

        }
        if (otherName == "LadderUp" && Input.GetKeyDown(KeyCode.E))
        {
           
                Level_Changer fn = GameObject.FindObjectOfType(typeof(Level_Changer)) as Level_Changer;
                fn.FadeToNextLevel();
            
        }
    }
}
