using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public Canvas canvas;

    public Button playButton;
    public Button exitButton;
    public Slider musicSlider;
    public Slider soundSlider;

    public AudioMixerGroup musicMixer;
    public AudioMixerGroup soundMixer;

    public InputActionProperty pauseButton;

    private void Update()
    {
        float triggerValue = pauseButton.action.ReadValue<float>();
        if (triggerValue == 1 && SceneManager.GetActiveScene().name != "MainMenu")
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
    }

    public void Show()
    {
        canvas.enabled = true;
    }
}
