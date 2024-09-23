using Agava.WebUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TestFocus : MonoBehaviour
{
    private const string Focus = "focus";

    [SerializeField] private GameStopControl _stopControl;
 
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
        PauseGame(!inApp);
    }

    private void OnInBackgroundChangeWeb(bool isBackground)
    {
        PauseGame(isBackground);
    }

    private void PauseGame(bool value)
    {
        if (value)
        {
            _stopControl.Stop(new PauseSource(Focus));
        }
        else
        {
            _stopControl.Play(new PauseSource(Focus));
        }
    }
}
