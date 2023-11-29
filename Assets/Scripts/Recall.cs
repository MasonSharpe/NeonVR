using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Recall : MonoBehaviour
{
    public static Recall instance;
    public GameObject lastGrabbedObject;
    public InputActionProperty recallButton;
    public TextMeshProUGUI text;
    public GameObject player;
    public bool canRecall = true;

    private void Update()
    {
        float triggerValue = recallButton.action.ReadValue<float>();
       // text.text = triggerValue.ToString();
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


    public void RecallObject()
    {
        lastGrabbedObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z + 1);
    }
}
