using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyhealth : MonoBehaviour
{

    public int health = 10;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        string otherTag = collision.gameObject.tag;
        if (otherTag == "PlayerBullet")
        {
            health -= 1;
            slider.value = health;
        }
        if (health <= 0)
        {
            Scene scence = SceneManager.GetActiveScene();
            SceneManager.LoadScene("");
        }
    }
}
