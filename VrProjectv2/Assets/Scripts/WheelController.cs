using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] MirrorRotationController controlledMirror;

    Transform modelTf;
    Transform grabTf;

    Rigidbody wheelRb;
    Rigidbody handleRb;

    public bool isGrabbed;

    float parentYRot;

    [DoNotSerialize] public float currentRotation;

    void Start()
    {
        if (controlledMirror == null)
            Debug.LogWarning("WheelController: " + gameObject.name + " isn't controlling a mirror");

        modelTf = GetComponent<Transform>();
        grabTf = transform.GetChild(1).GetComponentInChildren<Transform>();

        wheelRb = transform.GetChild(0).GetComponent<Rigidbody>();
        handleRb = transform.GetChild(1).GetComponent<Rigidbody>();

        wheelRb.constraints = RigidbodyConstraints.FreezeAll;
        handleRb.constraints = RigidbodyConstraints.FreezeAll;
        handleRb.constraints &= ~RigidbodyConstraints.FreezeRotationZ;

        isGrabbed = false;

        parentYRot = GetComponentInParent<Transform>().rotation.y;

        //Debug.Log(grabTf.position);
    }

    void Update()
    {
        if (isGrabbed)
        {
            /*parentXRot = transform.parent.rotation.eulerAngles.x;
            parentYRot = transform.parent.rotation.eulerAngles.y;

            Vector3 addVector1 = new Vector3(parentXRot, parentYRot, 0);
            addVector1.Normalize();
            Vector3 addVector = grabTf.position + addVector1;
            Debug.Log(addVector);

            Debug.DrawLine(grabTf.position, addVector);

            currentRotation = modelTf.rotation.eulerAngles.z;*/

            if (135 < parentYRot && parentYRot <= 180)
            {

            }
        }
        else
        {
            //grabTf.position = modelTf.position + new Vector3(0, -1, 0.5f);
            grabTf.position = handleRb.position;
        }

        controlledMirror.yRotation = currentRotation;
    }
}
