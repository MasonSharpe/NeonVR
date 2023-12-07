using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public static SongManager instance;
    public AudioSource[] sources;

    public bool isFading = false;
    public float fadeProgress = 0;
    public int fadeDestination = 0;
    public bool fadeDirection = false;
    public bool isHoldingBall = false;

    public void ChangeSourceState(int index)
    {
        int prev = fadeDestination;
        fadeDestination = index;
        fadeDirection = index > prev;
        isFading = true;
        fadeProgress = 0;
    }

    private void Update()
    {
        if (isFading)
        {
            fadeProgress += Time.deltaTime;

            if (fadeDirection)
            {
                if (fadeDestination < sources.Length) sources[fadeDestination].volume += 0.33f * Time.deltaTime;
            }
            else
            {
                if (fadeDestination + 1 < sources.Length) sources[fadeDestination + 1].volume -= 0.33f * Time.deltaTime;
            }


            if (fadeProgress >= 3)
            {
                isFading = false;
            }
        }
    }
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


}
