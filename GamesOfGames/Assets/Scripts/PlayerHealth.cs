using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 10;
    public TextMeshProUGUI healthtext;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //  healthtext.text = "Health: " + playerHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        string otherName = collision.gameObject.name; 
        if(otherName == "Spikes")
        {
            playerHealth--;
            if(playerHealth <= 0)
            {
                SceneManager.LoadScene("DeathScreen");
            }
        }
        if (collision.gameObject.tag == "Ball")
        {
            playerHealth--;
            if (playerHealth <= 0)
            {
                SceneManager.LoadScene("Start");
            }
        }
    }
}
