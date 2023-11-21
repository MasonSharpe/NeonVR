using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public DoorActivation connectedDoor;
    private int ballsOnPlate = 0;

    public GameObject lightObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            ballsOnPlate++;
            if (ballsOnPlate == 1)
            {
                connectedDoor.OpenDoor();
                lightObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            ballsOnPlate--;
            if (ballsOnPlate == 0)
            {
                connectedDoor.CloseDoor();
                lightObject.SetActive(false);
            }
        }

    }
}
