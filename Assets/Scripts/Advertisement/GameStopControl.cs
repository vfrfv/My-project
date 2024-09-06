using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameStopControl : MonoBehaviour
{
    public void Play()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1; 
    }

    public void Stop()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;
    }
}
