using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int level;
    public bool justDied;
    public int difficulty;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        level = 5;
        difficulty = 1;
        justDied = true;
    }
}
