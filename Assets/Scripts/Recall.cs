using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recall : MonoBehaviour
{
    public static Recall instance;
    public GameObject lastGrabbedObject;

    private void Awake()
    {
        instance = this;
    }
    public void SetLastGrabbedObject(GameObject gameObject)
    {
        lastGrabbedObject = gameObject;
    }
    public void RecallObject(GameObject hand)
    {
        lastGrabbedObject.transform.position = hand.transform.position;
        lastGrabbedObject.GetComponent<Rigidbody>().velocity = Vector3.up;
    }
}
