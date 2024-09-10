using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VideoAd : MonoBehaviour
{
    private const string Video = "video";

    [SerializeField] private Button _advertisement;
    [SerializeField] private PlayerPointsManager _playerPointsManager;
    [SerializeField] private ImageVictory _imageVictory;
    [SerializeField] private GameStopControl _stopControl;

    private float _points = 50;

    public event Action<float> looked;

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
        _stopControl.Play(new PauseSource(Video));
    }

    public void Stop()
    {
        _stopControl.Stop(new PauseSource(Video));
    }
}
