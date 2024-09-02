using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VideoAd : MonoBehaviour
{
    [SerializeField] private Button _advertisement;
    [SerializeField] private PlayerPointsManager _playerPointsManager;
    [SerializeField] private ImageVictory _imageVictory;

    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _sound;

    private float _points = 50;

    public event Action<float> looked;

    private void OnEnable()
    {
        _advertisement.onClick.AddListener(Show);
        _advertisement.onClick.AddListener(StopSound);
        _advertisement.interactable = true;
    }

    private void OnDisable()
    {
        _advertisement.onClick.RemoveListener(Show);
        _advertisement.onClick.RemoveListener(StopSound);
    }

    public void Show()
    {
        _music.volume = 0;
        _sound.volume = 0;

        _music.Stop();

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
        _music.Play();
        _sound.Play();

        _music.volume = 1;
        _sound.volume = 1;

        Time.timeScale = 1;
    }

    public void Stop()
    {
        _music.volume = 0;
        _sound.volume = 0;

        _music.Stop();
        _sound.Stop();

        Time.timeScale = 0;
    }

    private void StopSound()
    {
        _music.volume = 0;
        _sound.volume = 0;

        _music.Stop();
        _sound.Stop();
    }
}
