using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStopControl : MonoBehaviour
{
    public void Play()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void Stop()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
}
