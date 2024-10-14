using UnityEngine;

public class InterstitialAd : MonoBehaviour
{
    private const string Interstitial = "interstitial";

    [SerializeField] private GameStopControl _gameStopControl;
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
        _gameStopControl.Play(new PauseSource(Interstitial));
    }

    public void Stop()
    {
        _gameStopControl.Stop(new PauseSource(Interstitial));
    }
}