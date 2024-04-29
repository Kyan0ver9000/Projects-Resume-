using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class ButtonOrderController : MonoBehaviour
{
    /*[DoNotSerialize]*/ public List<GameObject> buttons = new List<GameObject>();

    [DoNotSerialize] public List<int> buttonOrder = new List<int>();
    List<int> correctOrder = new List<int>();

    Animator doorAnim;

    [DoNotSerialize] public bool doorIsOpen;

    bool temp;

    void Awake()
    {
        foreach(Transform buttonGO in GameObject.Find("ButtonsParent").GetComponentsInChildren<Transform>())
        {
            if (buttonGO.gameObject.name != "ButtonsParent")
                buttons.Add(buttonGO.gameObject);
        }

        if (buttons.Count != 8)
            Debug.LogWarning("One or more of the buttons for the ButtonOrderController is not set");

        ClearCode();

        correctOrder.Add(4);
        correctOrder.Add(6);
        correctOrder.Add(1);
        correctOrder.Add(7);

        if (correctOrder.Count != 4)
        {
            Debug.LogError("Correct Button Code isn't the right length");
        }

        doorIsOpen = false;
    }

    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }


    void Update()
    {
        if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName("DoorOpen1"))
            temp = true;
        else
            temp = false;

        if (buttonOrder.Count == 4)
            CheckIfCodeIsCorrect();
    }

    void CheckIfCodeIsCorrect()
    {
        if (buttonOrder.SequenceEqual(correctOrder))
        {
            ActivateDoor();
        }
        else
        {
            ClearCode();
        }
    }

    void ActivateDoor()
    {
        doorIsOpen = true;
        doorAnim.SetTrigger("Open");
        Destroy(doorAnim.gameObject);
    }
    
    public void ClearCode()
    {
        buttonOrder.Clear();
    }
}
