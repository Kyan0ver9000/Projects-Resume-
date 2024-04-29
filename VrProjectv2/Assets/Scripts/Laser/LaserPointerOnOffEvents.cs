using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserPointerOnOffEvents : MonoBehaviour
{
    [SerializeField] LaserPointerController laserController;

    [DoNotSerialize] public bool isEquippedOnOff;
    public bool ableToPower;

    void Start()
    {
        ableToPower = false;
    }

    void Update()
    {
        isEquippedOnOff = laserController.isEquipped;

        if (!isEquippedOnOff)
        {
            ableToPower = false;
        }
    }

    public void StartTurnOn()
    {
        ableToPower = false;
    }

    public void MidTurnOn()
    {
        laserController.GetComponentInChildren<LineRenderer>().enabled = true;
    }

    public void EndTurnOn()
    {
        ableToPower = false;
    }

    public void StartTurnOff()
    {
        ableToPower = false;
    }

    public void MidTurnOff()
    {
        laserController.GetComponentInChildren<LineRenderer>().enabled = false;
    }

    public void EndTurnOff()
    {
        ableToPower = false;
    }
}
