using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VideoAd : MonoBehaviour
{
    [SerializeField] private Button _advertisement;
    [SerializeField] private PlayerPointsManager _playerPointsManager;
    [SerializeField] private ImageVictory _imageVictory;

    [SerializeField] private AudioSource[] _sounds;

    private float _points = 50;

    public event Action<float> looked;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        _advertisement.onClick.AddListener(Show);
        _advertisement.interactable = true;
    }

    private void OnDisable()
    {
        _advertisement.onClick.RemoveListener(Show);
    }

    public void Show()
    {
        Agava.YandexGames.VideoAd.Show(Stop, OnRewardCallback, Play);
        _advertisement.interactable = false;
    }

    private void OnRewardCallback()
    {
        looked?.Invoke(_points);
        _playerPointsManager.AddPoints(_points);
    }

    public void Play()
    {
        Time.timeScale = 1;

        foreach (var sound in _sounds)
        {
            sound.volume = 1;
        }
    }

    public void Stop()
    {
        Time.timeScale = 0;

        foreach(var sound in _sounds)
        {
            sound.volume = 0;
            Debug.Log("«вук на ноль");
        }
    }
}
