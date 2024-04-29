using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class BeamController : MonoBehaviour
{
    GameObject icosphere;

    LaserPointerController laserController;

    LineRenderer lr;

    [DoNotSerialize] public int laserStrength;
    int maxReflections = 100;

    LayerMask laserNoCollideMask;

    void Start()
    {
        icosphere = GameObject.Find("Icosphere");
        laserController = GetComponentInParent<LaserPointerController>();
        lr = GetComponent<LineRenderer>();

        laserNoCollideMask = LayerMask.GetMask("Glass");

        lr.enabled = false;

        lr.positionCount = maxReflections + 1;
    }

    void Update()
    {
        if (laserController.isOn)
        {
            CastLaser(transform.position, transform.up);
        }
    }

    void CastLaser(Vector3 position, Vector3 direction)
    {
        lr.SetPosition(0, icosphere.transform.position);

        for (int i = 0; i < maxReflections; i++)
        {
            //Debug.Log(position + ", " + direction);
            Ray ray = new Ray(position, direction);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 500, ~laserNoCollideMask))
            {
                position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                lr.SetPosition(i + 1, hit.point);

                LaserPointDetector tempLpd = new LaserPointDetector();

                if (hit.collider.gameObject.tag == "LaserTrigger" && hit.collider.gameObject.GetComponent<LaserPointDetector>() && laserStrength <= hit.collider.gameObject.GetComponent<LaserPointDetector>().activateStrength)
                {
                    tempLpd = hit.collider.gameObject.GetComponent<LaserPointDetector>();
                    tempLpd.animTrigger = true;
                }
                else
                {
                    if (tempLpd)
                        tempLpd.animTrigger = false;
                    tempLpd = null;
                }

                if (hit.collider.gameObject.tag == "Gem" && hit.collider.gameObject.GetComponent<GemController>())
                {
                    hit.collider.gameObject.GetComponent<GemController>().LaserTargeted();
                }

                if (hit.collider.gameObject && hit.collider.gameObject.tag != "Mirror")
                {
                    laserStrength = i;

                    for (int j = (i + 1); j <= maxReflections; j++)
                    {
                        lr.SetPosition(j, hit.point);
                    }
                    break;
                }
            }
            else
            {
                lr.SetPosition(i + 1, ray.GetPoint(500));

                for (int j = (i + 2); j <= maxReflections; j++)
                {
                    lr.SetPosition(j, lr.GetPosition(i + 1));
                }
                break;
            }
        }
    }
}
