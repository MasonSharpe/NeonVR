using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivation : MonoBehaviour
{
    public Collider areaCollider;
    public MeshRenderer areaVisual;
    public bool activatedByKey = true;

    public void OpenDoor()
    {
        areaCollider.enabled = false;
        areaVisual.enabled = false;
    }

    public void CloseDoor()
    {
        areaCollider.enabled = true;
        areaVisual.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10 && activatedByKey)
        {
            OpenDoor();
            Destroy(other.transform.parent.gameObject);
        }
    }
}
