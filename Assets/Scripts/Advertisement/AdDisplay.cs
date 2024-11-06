using Conservation;
using Infrastructure.UI;
using Manager;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Advertisement
{
    public class AdDisplay : MonoBehaviour
    {
        private const string Video = "video";

        [SerializeField] private Button _advertisement;
        [SerializeField] private PlayerPointsSaver _playerPointSaver;
        [SerializeField] private VictoryPanel _imageVictory;
        [SerializeField] private PauseHandler _pauseManager;
        [SerializeField] private LevelNavigator _levelManager;

        private readonly float _points = 50;

        public event Action<float> Looked;

        private void OnEnable()
        {
            _advertisement.onClick.AddListener(ShowVideoAd);
            _advertisement.interactable = true;
            _imageVictory.Pressed += ShowInterstitialAd;
        }

        private void OnDisable()
        {
            _advertisement.onClick.RemoveListener(ShowVideoAd);
            _imageVictory.Pressed -= ShowInterstitialAd;
        }

        private void ShowVideoAd()
        {
            Agava.YandexGames.VideoAd.Show(Stop, OnRewardCallback, Play);
            _advertisement.interactable = false;
        }

        private void ShowInterstitialAd()
        {
            Agava.YandexGames.InterstitialAd.Show(Stop, OnClose);
        }

        private void OnClose(bool _)
        {
            _levelManager.LoadNextLevel();
            Play();
        }

        private void OnRewardCallback()
        {
            Looked?.Invoke(_points);
            _playerPointSaver.AddPoints(_points);
        }

        private void Play()
        {
            _pauseManager.Play(new PauseSource(Video));
        }

        private void Stop()
        {
            _pauseManager.Stop(new PauseSource(Video));
        }
    }
}