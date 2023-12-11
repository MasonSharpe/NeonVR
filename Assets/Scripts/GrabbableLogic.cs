using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableLogic : MonoBehaviour
{
    public AudioSource source;
    public AudioClip impactClip;
    public AudioClip throwClip;
    public void SetRecallObject()
    {
        Recall.instance.SetLastGrabbedObject(gameObject);

        if (gameObject.layer == 12)
        {
            SongManager.instance.ChangeSourceState(SongManager.instance.fadeDestination + 1);
        }
    }

    public void DropObject()
    {
        if (gameObject.layer == 12)
        {
            SongManager.instance.ChangeSourceState(SongManager.instance.fadeDestination - 1);
        }
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > 3)
        {
            source.PlayOneShot(throwClip);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 0)
        {
            source.PlayOneShot(impactClip);
        }
    }
}
