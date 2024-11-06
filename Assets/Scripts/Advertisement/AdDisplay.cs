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
        [SerializeField] private Button _nextLevel;

        private readonly float _points = 50;

        private void OnEnable()
        {
            _advertisement.onClick.AddListener(ShowVideoAd);
            _advertisement.interactable = true;
            _nextLevel.onClick.AddListener(ShowInterstitialAd);
        }

        private void OnDisable()
        {
            _advertisement.onClick.RemoveListener(ShowVideoAd);
            _nextLevel.onClick.RemoveListener(ShowInterstitialAd);
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