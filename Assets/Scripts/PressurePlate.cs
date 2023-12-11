using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public DoorActivation connectedDoor;
    private int ballsOnPlate = 0;

    public GameObject lightObject;
    public Collider lightCollider;
    public Vector3 lightPosition;

    public AudioSource source;
    public AudioClip onClip;
    public AudioClip offClip;

    private void Start()
    {
        lightPosition = lightObject.transform.position;
        lightObject.transform.position = Vector3.down * 100;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12 && other != lightCollider)
        {
            ballsOnPlate++;
            if (ballsOnPlate == 1)
            {
                connectedDoor.OpenDoor();
                lightObject.transform.position = lightPosition;
                source.PlayOneShot(onClip);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 12 && other != lightCollider)
        {
            ballsOnPlate--;
            if (ballsOnPlate == 0)
            {
                connectedDoor.CloseDoor();
                lightObject.transform.position = Vector3.down * 100;
                source.PlayOneShot(offClip);

            }
        }

    }
}
