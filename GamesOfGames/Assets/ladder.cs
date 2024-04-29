using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        string otherName = collision.gameObject.name;
        if (otherName == "Player" && Input.GetKey(KeyCode.E))
        {

            Level_Changer fn = GameObject.FindObjectOfType(typeof(Level_Changer)) as Level_Changer;
            fn.FadeToNextLevel();

        }

    }
}
