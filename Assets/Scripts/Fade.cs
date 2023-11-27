using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    public static Fade instance;
    [SerializeField] private RawImage sprite;
    private float fadeTimer;
    private bool isShowing;

    private void Awake() {
        instance = this;
        DontDestroyOnLoad(GetComponentInParent<Canvas>().gameObject);
    }

    public void Show() {
        isShowing = true;
        fadeTimer = 0.2f;
    }

    public void Hide() {
        isShowing = false;
        fadeTimer = 0.2f;
    }

    private void Update() {
        fadeTimer -= Time.deltaTime;
        sprite.color = new Color(0, 0, 0, isShowing ? (0.2f - fadeTimer) / 0.2f : fadeTimer / 0.2f);
        if (fadeTimer <= 0)
        {
            
        }
    }
}