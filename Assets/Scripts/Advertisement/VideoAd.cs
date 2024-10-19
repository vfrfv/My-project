using Assets.Scripts.Conservation;
using Assets.Scripts.Infrastructure.UI;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Advertisement
{
    public class VideoAd : MonoBehaviour
    {
        private const string Video = "video";

        [SerializeField] private Button _advertisement;
        [SerializeField] private PlayerPointsSaver _playerPointSaver;
        [SerializeField] private ImageVictory _imageVictory;
        [SerializeField] private PauseManager _pauseManager;

        private readonly float _points = 50;

        public float Points => _points;

        public event Action<float> Looked;

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
            Looked?.Invoke(_points);
            _playerPointSaver.AddPoints(_points);
        }

        public void Play()
        {
            _pauseManager.Play(new PauseSource(Video));
        }

        public void Stop()
        {
            _pauseManager.Stop(new PauseSource(Video));
        }
    }
}