using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterstitialAd : MonoBehaviour
{
    [SerializeField] private Button _advertisement;
    [SerializeField] private GameStopControl _gameStopControl;

    private void Awake()
    {
        _advertisement.onClick.AddListener(Show);
    }

    private void OnDisable()
    {
        _advertisement.onClick.RemoveListener(Show);
    }

    public void Show()
    {
        Agava.YandexGames.InterstitialAd.Show(_gameStopControl.Stop, OnClose);
    }

    private void OnClose(bool value)
    {
        _gameStopControl.Play();
    }
}
