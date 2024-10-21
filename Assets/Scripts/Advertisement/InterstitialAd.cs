using Infrastructure.UI;
using UnityEngine;

namespace Advertisement
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

        private void Show()
        {
            Agava.YandexGames.InterstitialAd.Show(Stop, OnClose);
        }

        private void Play()
        {
            _pauseManager.Play(new PauseSource(Interstitial));
        }

        private void Stop()
        {
            _pauseManager.Stop(new PauseSource(Interstitial));
        }

        private void OnClose(bool _)
        {
            _imageVictory.LaunchNextLevel();
            Play();
        }
    }
}