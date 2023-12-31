using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MainMenu : MonoBehaviour
{
    public Canvas canvas;

    public Button playButton;
    public Button exitButton;
    public Slider musicSlider;
    public Slider soundSlider;

    public AudioMixerGroup musicMixer;
    public AudioMixerGroup soundMixer;

    public XRRayInteractor leftRay;
    public XRRayInteractor rightRay;

    public InputActionProperty pauseButton;

    private void Update()
    {
        float triggerValue = pauseButton.action.ReadValue<float>();
        //Recall.instance.text.text = triggerValue.ToString();
        if ((triggerValue == 1 || Input.GetKeyDown(KeyCode.Escape)) && SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (canvas.enabled)
            {
                Resume();
            }
            else
            {
                Show();
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MusicSliderChanged()
    {
        musicMixer.audioMixer.SetFloat("Volume", Mathf.Log10(musicSlider.value) * 20);
    }

    public void SoundSliderChanged()
    {
        soundMixer.audioMixer.SetFloat("SFXVolume", Mathf.Log10(soundSlider.value) * 20);
    }

    public void Resume()
    {
        canvas.enabled = false;
        leftRay.enableUIInteraction = false;
        rightRay.enableUIInteraction = false;
    }

    public void Show()
    {
        canvas.enabled = true;
        leftRay.enableUIInteraction = true;
        rightRay.enableUIInteraction = true;
    }

    public void ChangeDifficulty(int value)
    {
        GameManager.instance.difficulty = value;
    }
}
