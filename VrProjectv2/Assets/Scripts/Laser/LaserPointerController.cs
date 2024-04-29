using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class LaserPointerController : MonoBehaviour
{
    public InputActionReference bButton;

    Animator buttonAnim;
    LaserPointerOnOffEvents animEvents;

    [DoNotSerialize] public bool isEquipped;
    [DoNotSerialize] public bool isOn;

    void Start()
    {
        bButton.action.started += LaserToggle;

        buttonAnim = transform.GetChild(0).GetComponentInChildren<Animator>();
        animEvents = buttonAnim.gameObject.GetComponent<LaserPointerOnOffEvents>();

        isOn = false;
    }

    private void Update()
    {
        GameObject.Find("TestText").GetComponentInChildren<TextMeshProUGUI>().text = isOn.ToString();
    }

    void OnDestroy()
    {
        bButton.action.started -= LaserToggle;
    }

    void LaserToggle(InputAction.CallbackContext context)
    {
        //if (!animEvents.ableToPower)
        //{
            isOn = !isOn;
            buttonAnim.SetTrigger("ButtonPressed");
        //}
    }
}
