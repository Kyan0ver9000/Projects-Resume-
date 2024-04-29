using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }
    public GameObject Aim;
    private Transform aimGunEndPointTransform;
    private Transform aimTransform;
    private Animator aimAnimator;
    private void Awake()
    {
        aimTransform = GameObject.Find("Aim").transform;
        aimGunEndPointTransform = GameObject.Find("GunEndPointPosition").transform;
        aimAnimator = aimTransform.GetComponent<Animator>();
    }

    private void Update()
    {
        HandleAiming();
        HandleShooting();
    }


    private void HandleAiming()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 aimDir = mousePosition - transform.position;
        aimDir.Normalize();
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
     

        Vector3 aimLocalScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            aimLocalScale.y = -1f;
        }else
        {
            aimLocalScale.y = +1f;
        }
        aimTransform.localScale = aimLocalScale;
    }

    private void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            aimAnimator.SetTrigger("Shoot");
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                gunEndPointPosition = aimGunEndPointTransform.position,
                shootPosition = mousePosition,
            });
        }
    }

}