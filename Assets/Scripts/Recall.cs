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

    public AudioSource source;
    public AudioClip onClip;
    public AudioClip deathClip;
    public AudioClip winClip;

    private void Update()
    {
        float triggerValue = recallButton.action.ReadValue<float>();
        
        if (triggerValue == 1 && canRecall)
        {
            canRecall = false;
            RecallObject();
        }
        if (triggerValue != 1 && !canRecall)
        {
            canRecall = true;
        }

        float restartValue = restartButton.action.ReadValue<float>();
        if (restartValue == 1)
        {
            GameManager.instance.justDied = true;
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
        if (GameManager.instance.justDied)
        {
            source.PlayOneShot(deathClip);
        }
        else
        {
            source.PlayOneShot(deathClip);
        }
    }
    public void SetLastGrabbedObject(GameObject gameObject)
    {
        lastGrabbedObject = gameObject;
    }


    public void RecallObject()
    {
        if (lastGrabbedObject != null)
        {
            source.PlayOneShot(onClip);

            lastGrabbedObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
            lastGrabbedObject.GetComponent<Rigidbody>().velocity = Vector3.up * 4;
        }

    }
}
