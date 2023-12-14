using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    private float cutsceneTime = 0;
    public GameObject player;
    public AnimationCurve ease;

    private void Update()
    {
        cutsceneTime += Time.deltaTime;
        player.transform.Rotate(new Vector3(0, ease.Evaluate(cutsceneTime), 0));

        if (cutsceneTime > 9)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
