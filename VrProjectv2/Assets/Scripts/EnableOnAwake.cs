using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnAwake : MonoBehaviour
{
    [SerializeField] ButtonOrderController boc;
    void Awake()
    {
        boc.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
