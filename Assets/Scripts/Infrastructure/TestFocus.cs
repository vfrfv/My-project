using Agava.WebUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TestFocus : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
 
    private void OnEnable()
    {
        Application.focusChanged += OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
    }

    private void OnDisable()
    {
        Application.focusChanged -= OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
    }

    private void OnInBackgroundChangeApp(bool inApp)
    {
        MuteAudio(!inApp);
        PauseGame(!inApp);
    }

    private void OnInBackgroundChangeWeb(bool isBackground)
    {
        MuteAudio(isBackground);
        PauseGame(isBackground);
    }

    private void MuteAudio(bool value)
    {
        if (value == false)
        {
            _audioMixerGroup.audioMixer.SetFloat("Master", 0);
        }

        if (value == true)
        {
            _audioMixerGroup.audioMixer.SetFloat("Master", -80);
        }
    }

    private void PauseGame(bool value)
    {
        Time.timeScale = value ? 0 : 1;
    }
}
