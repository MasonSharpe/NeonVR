using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableLogic : MonoBehaviour
{

    public void SetRecallObject()
    {
        Recall.instance.SetLastGrabbedObject(gameObject);

        if (gameObject.layer == 12)
        {
            SongManager.instance.ChangeSourceState(SongManager.instance.fadeDestination + 1);
            SongManager.instance.isHoldingBall = true;
        }
    }

    public void DropObject()
    {
        if (gameObject.layer == 12)
        {
            SongManager.instance.ChangeSourceState(SongManager.instance.fadeDestination - 1);
            SongManager.instance.isHoldingBall = false;
        }
    }


}
