using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class ButtonPressTrigger : MonoBehaviour
{
    ButtonOrderController boc;
    int thisButtonNumber;

    void Start()
    {
        boc = GameObject.Find("Door 1").GetComponent<ButtonOrderController>();

        foreach(GameObject buttonGO in boc.buttons)
        {
            if (gameObject == buttonGO)
                thisButtonNumber = boc.buttons.IndexOf(buttonGO) + 1;
        }

        if (thisButtonNumber <= 0 || thisButtonNumber >= 9)
            Debug.LogWarning("ButtonPressTrigger: thisButtonNumber isn't correct on " + gameObject.name);
    }

    public void ButtonPress()
    {
        boc.buttonOrder.Add(thisButtonNumber);
    }
}
