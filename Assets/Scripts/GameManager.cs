using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int level;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}