using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 50;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject BossDoor;
        if (collision.gameObject.tag == "PlayerBullet")
        {
            health--;
            if (health <= 0)
            {

                BossDoor = GameObject.Find("BossDoor");
                Destroy(BossDoor);
                Destroy(gameObject);
            }
        }
    }
}