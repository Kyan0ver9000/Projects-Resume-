using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GemHolderController : MonoBehaviour
{
    [DoNotSerialize] public bool gem1Held;
    [DoNotSerialize] public bool gem2Held;
    [DoNotSerialize] public bool gem3Held;

    void Start()
    {
        gem1Held = false;
        gem2Held = false;
        gem3Held = false;
    }
}
