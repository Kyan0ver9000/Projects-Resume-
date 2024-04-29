using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MirrorRotationController : MonoBehaviour
{
    Transform rotPointTf;

    /*[DoNotSerialize]*/ public float yRotation;

    void Start()
    {
        rotPointTf = transform;
        yRotation = rotPointTf.rotation.eulerAngles.y;
    }

    void FixedUpdate()
    {
        rotPointTf.eulerAngles = new Vector3(rotPointTf.rotation.x, yRotation, rotPointTf.rotation.z);
    }
}