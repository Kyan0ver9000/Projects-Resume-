using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GemController : MonoBehaviour
{
    Animator anim;
    XRGrabInteractable interactable;
    GemHolderController ghc;

    int gemNumber;
    [DoNotSerialize] public bool ableToInteract;
    [DoNotSerialize] public bool isLaserTarget;

    void Start()
    {
        anim = GetComponent<Animator>();
        interactable = GetComponent<XRGrabInteractable>();
        ghc = GameObject.Find("GemHolder").GetComponent<GemHolderController>();

        if (gameObject.name == "Gem1")
            gemNumber = 1;
        else if (gameObject.name == "Gem2")
            gemNumber = 2;
        else if (gameObject.name == "Gem3")
            gemNumber = 3;
        else
            Debug.LogWarning("Unneeded GemController on " + gameObject.name);
        
        ableToInteract = true;
        isLaserTarget = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (ableToInteract)
        {
            if (other.gameObject.name == "Gem1Slot" && gemNumber == 1)
            {
                anim.SetTrigger("Play");
                DisableInteractions();
            }
            else if (other.gameObject.name == "Gem2Slot" && gemNumber == 2)
            {
                anim.SetTrigger("Play");
                DisableInteractions();
            }
            else if (other.gameObject.name == "Gem3Slot" && gemNumber == 3)
            {
                anim.SetTrigger("Play");
                DisableInteractions();
            }
        }
    }

    void DisableInteractions()
    {
        ableToInteract = false;
        interactable.enabled = false;
    }
    
    public void GemIsSet()
    {
        if (gemNumber == 1)
            ghc.gem1Held = true;
        else if (gemNumber == 2)
            ghc.gem2Held = true;
        else if (gemNumber == 3)
            ghc.gem3Held = true;

        isLaserTarget = true;

        anim.SetTrigger("Finish");
    }

    public void LaserTargeted()
    {
        // Do Stuff
    }
}
