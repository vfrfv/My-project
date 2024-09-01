using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameStopControl : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private int i = 0;

    public void Play()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1; 
        //_mixerGroup.audioMixer.SetFloat("Master", -80);
    }

    public void Stop()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;

        i = 1;
        Debug.Log($"Игра на стопе {i}");
        //_mixerGroup.audioMixer.SetFloat("Master", 0);
    }
}
