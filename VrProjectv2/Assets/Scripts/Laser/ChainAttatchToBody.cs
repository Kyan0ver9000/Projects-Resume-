using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainAttatchToBody : MonoBehaviour
{
    public Transform attatchPoint;

    void Update()
    {
        transform.position = attatchPoint.position;
    }
}
