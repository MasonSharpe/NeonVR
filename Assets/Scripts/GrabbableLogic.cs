using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableLogic : MonoBehaviour
{

    public void SetRecallObject()
    {
        Recall.instance.SetLastGrabbedObject(gameObject);
    }

    public void SetRecallPosition()
    {
        Recall.instance.SetObjectRecallPosition();
    }
}
