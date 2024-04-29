using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject player;
    public GameObject prefab;
    public float bulletSpeed = 10.0f;
    public float bulletLifetime = 2.0f;
   public AudioClip shootSound;

    private void Awake()
    {
        GetComponent<PlayerAimWeapon>().OnShoot += PlayerShootProjectiles_OnShoot;

    }
    //When Left Mouse is Clicked Fire Bullet
    //Dependent on where user mouse is located 
    //Then apply bulletLifetime to issure the bullet disapears after a set time period.
    public void PlayerShootProjectiles_OnShoot(object sender, PlayerAimWeapon.OnShootEventArgs e)
        {

            if (Input.GetButtonDown("Fire1"))
            {



                GameObject bullet = Instantiate(prefab, e.gunEndPointPosition, Quaternion.identity);
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector2 shootDir = mousePosition - transform.position;
                shootDir.Normalize();
                bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
                Destroy(bullet, bulletLifetime);
                Camera.main.GetComponent<AudioSource>().PlayOneShot(shootSound);


            }
        }
     
    
}
