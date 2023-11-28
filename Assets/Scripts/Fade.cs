using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

    public static Fade instance;
    [SerializeField] private RawImage sprite;
    private float fadeTimer;
    private bool isShowing = false;

    private void Awake() {
        instance = this;
        DontDestroyOnLoad(GetComponentInParent<Canvas>().gameObject);
    }

    public void Show() {
        isShowing = true;
        fadeTimer = 2f;
    }

    public void Hide() {
        isShowing = false;
        fadeTimer = 2f;
    }

    private void Update() {
        fadeTimer -= Time.deltaTime;
        sprite.color = new Color(0, 0, 0, isShowing ? (2f - fadeTimer) / 2f : fadeTimer / 2f);
        if (fadeTimer <= -1 && isShowing)
        {
            SceneManager.LoadScene("Level" + ++GameManager.instance.level);
            isShowing = false;
            Hide();
        }
    }
}