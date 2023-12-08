using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class Recall : MonoBehaviour
{
    public static Recall instance;
    public GameObject lastGrabbedObject;
    public InputActionProperty recallButton;
    public InputActionProperty restartButton;
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

        float restartValue = recallButton.action.ReadValue<float>();
        if (triggerValue >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player.transform.localPosition = Vector3.zero;
    }
    public void SetLastGrabbedObject(GameObject gameObject)
    {
        lastGrabbedObject = gameObject;
    }


    public void RecallObject()
    {
        if (lastGrabbedObject != null)
        {
            lastGrabbedObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
            lastGrabbedObject.GetComponent<Rigidbody>().velocity = Vector3.up * 4;
        }

    }
}
