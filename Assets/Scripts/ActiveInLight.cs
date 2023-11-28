using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInLight : MonoBehaviour
{
    public Collider areaCollider;
    public Collider lightCollider;
    public MeshRenderer areaVisual;
    public GameObject genericObject;
    public bool generic = false;
    public bool reversed = false;
    public int totalLights = 0;

    private void Start()
    {
        lightCollider.enabled = true;

        ToggleState(reversed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            totalLights++;
            if (totalLights > 0) ToggleState(!reversed);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.layer == 8)
        {
            totalLights--;
            if (totalLights <= 0) ToggleState(reversed);
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
