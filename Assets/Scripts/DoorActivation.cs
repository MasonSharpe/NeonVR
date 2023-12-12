using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivation : MonoBehaviour
{
    public Collider areaCollider;
    public MeshRenderer areaVisual;
    public bool activatedByKey = true;
    public bool reversed = false;

    public AudioSource source;
    public AudioClip unlockClip;

    public void OpenDoor()
    {
        areaCollider.enabled = reversed;
        areaVisual.enabled = reversed;
    }

    public void CloseDoor()
    {
        areaCollider.enabled = !reversed;
        areaVisual.enabled = !reversed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10 && activatedByKey)
        {
            OpenDoor();
            Destroy(other.transform.parent.gameObject);
            source.PlayOneShot(unlockClip);
        }
    }
}
