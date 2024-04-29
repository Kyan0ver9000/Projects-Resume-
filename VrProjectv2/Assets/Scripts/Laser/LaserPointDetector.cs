using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserPointDetector : MonoBehaviour
{
    [SerializeField] GameObject activateObject;
    Animator activateObjectAnim;
    //[SerializeField] Color acticvateColor;
    public int activateStrength;

    Animator thisAnim;
    BeamController bc;

    [DoNotSerialize] public bool animTrigger;

    bool animCanReset;

    void Awake()
    {
        if (activateObject.GetComponent<Animator>())
            activateObjectAnim = activateObject.GetComponent<Animator>();
        else
            Debug.LogWarning("LaserPointDetector's activateObjectAnim is null");

        if (GetComponent<Animator>())
            thisAnim = GetComponent<Animator>();

        bc = GameObject.Find("LineRenderer").GetComponent<BeamController>();
    }

    void Start()
    {
        if (activateObject == null)
            Debug.LogWarning(this.gameObject.name + " does not have an activateObject");
        //if (acticvateColor == null)
            //acticvateColor = Color.white;
        if (activateStrength == 0)
            activateStrength = 999;

        animTrigger = false;

        animCanReset = false;
    }

    void FixedUpdate()
    {
        if (animTrigger)
        {
            if (thisAnim.GetCurrentAnimatorStateInfo(0).IsName("LaserDetectorOff"))
            {
                thisAnim.SetTrigger("LaserTargetedFirst");
            }
            else if (thisAnim.GetCurrentAnimatorStateInfo(0).IsName("LaserDetectorActivate"))
            {
                thisAnim.speed = 1;
                animCanReset = true;
            }
        }
        else if (thisAnim.GetCurrentAnimatorStateInfo(0).IsName("LaserDetectorActivate"))
        {
            thisAnim.speed = -1;
        }
    }

    /*public void DoTrigger()
    {
        if (bc.laserStrength < activateStrength)
        {
            animTrigger = true;
        }
    }*/

    public void ResetState()
    {
        if (animCanReset)
        {
            thisAnim.SetTrigger("ResetState");
        }
    }

    public void TriggerOtherObjectEvent()
    {
        thisAnim.SetTrigger("LaserFinishTarget");
        activateObjectAnim.SetTrigger("LaserTrigger");
    }
}
