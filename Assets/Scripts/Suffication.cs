using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Suffication : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

    }
}
