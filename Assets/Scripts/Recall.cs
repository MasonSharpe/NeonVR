using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Recall : MonoBehaviour
{
    public static Recall instance;
    public GameObject lastGrabbedObject;
    public Vector3 lastObjectPosition = Vector3.zero;
    public InputActionProperty recallButton;
    public bool canRecall = true;

    private void Update()
    {
        float triggerValue = recallButton.action.ReadValue<float>();
        if (triggerValue >= 1 && canRecall)
        {
            canRecall = false;
            RecallObject();
        }
        if (triggerValue <= 0 && !canRecall)
        {
            canRecall = true;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    public void SetLastGrabbedObject(GameObject gameObject)
    {
        lastGrabbedObject = gameObject;
    }

    public void SetObjectRecallPosition()
    {
        lastObjectPosition = lastGrabbedObject.transform.position;
    }
    public void RecallObject()
    {
        lastGrabbedObject.transform.position = lastObjectPosition;
    }
}
