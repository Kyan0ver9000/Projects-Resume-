using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabEventsController : MonoBehaviour
{
    public Transform leftHandAttach;
    public Transform rightHandAttach;

    [SerializeField] List<WheelController> wc = new List<WheelController>();

    LaserPointerController lpc;

    void Awake()
    {
        lpc = GameObject.Find("Laser Pointer Parent").GetComponent<LaserPointerController>();
    }

    public void TriggerGrabStart(bool isLeftHand)
    {
        if (isLeftHand)
        {
            leftHandAttach = GameObject.Find("Left Controller").GetComponent<XRDirectInteractor>().attachTransform;

            foreach (WheelController wheelCont in wc)
            {
                if (wheelCont.GetComponentInParent<Transform>().GetComponentInParent<Transform>() == leftHandAttach)
                {
                    wheelCont.isGrabbed = true;
                }
            }

            if (leftHandAttach == lpc)
            {
                lpc.isEquipped = true;
            }
        }
        else
        {
            rightHandAttach = GameObject.Find("Right Controller").GetComponent<XRDirectInteractor>().attachTransform;

            foreach (WheelController wheelCont in wc)
            {
                if (wheelCont.GetComponentInParent<Transform>().GetComponentInParent<Transform>() == rightHandAttach)
                {
                    wheelCont.isGrabbed = true;
                }
            }

            if (rightHandAttach == lpc)
            {
                lpc.isEquipped = true;
            }
        }
    }

    public void TriggerGrabEnd(bool isLeftHand)
    {
        if (isLeftHand)
        {
            foreach (WheelController wheelCont in wc)
            {
                if (wheelCont.GetComponentInParent<Transform>().GetComponentInParent<Transform>() == leftHandAttach)
                {
                    wheelCont.isGrabbed = false;
                }
            }

            if (leftHandAttach == lpc)
            {
                lpc.isEquipped = false;
            }

            leftHandAttach = null;
        }
        else
        {
            foreach (WheelController wheelCont in wc)
            {
                if (wheelCont.GetComponentInParent<Transform>().GetComponentInParent<Transform>() == rightHandAttach)
                {
                    wheelCont.isGrabbed = false;
                }
            }

            if (rightHandAttach == lpc)
            {
                lpc.isEquipped = false;
            }

            rightHandAttach = null;
        }
    }
}
