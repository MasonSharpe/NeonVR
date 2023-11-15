using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInLight : MonoBehaviour
{
    public Collider areaCollider;
    public MeshRenderer areaVisual;
    public GameObject genericObject;
    public bool generic = false;
    public bool reversed = false;
    public bool startEnabled = false;

    private void Start()
    {
        ToggleState(startEnabled);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            ToggleState(!reversed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            ToggleState(reversed);
        }
    }

    private void ToggleState(bool state)
    {
        if (generic)
        {
            genericObject.SetActive(state);
        }
        else
        {
            areaCollider.enabled = state;
            areaVisual.enabled = state;
        }
    }
}
