using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && !triggered)
        {
            GameManager.instance.justDied = false;
            Fade.instance.Show();
            triggered = true;
        }
        
    }
}
