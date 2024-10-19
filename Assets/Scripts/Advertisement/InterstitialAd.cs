using Assets.Scripts.Infrastructure.UI;
using UnityEngine;

namespace Assets.Scripts.Advertisement
{
    public class InterstitialAd : MonoBehaviour
    {
        private const string Interstitial = "interstitial";

        [SerializeField] private PauseManager _pauseManager;
        [SerializeField] private ImageVictory _imageVictory;

        private void OnEnable()
        {
            _imageVictory.Pressed += Show;
        }

        private void OnDisable()
        {
            _imageVictory.Pressed -= Show;
        }

        public void Show()
        {
            Agava.YandexGames.InterstitialAd.Show(Stop, OnClose);
        }

        private void OnClose(bool _value)
        {
            _imageVictory.LaunchNextLevel();
            Play();
        }

        public void Play()
        {
            _pauseManager.Play(new PauseSource(Interstitial));
        }

        public void Stop()
        {
            _pauseManager.Stop(new PauseSource(Interstitial));
        }
    }
}