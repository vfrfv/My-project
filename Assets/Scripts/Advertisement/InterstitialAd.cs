using UnityEngine;

public class InterstitialAd : MonoBehaviour
{
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

    private void OnClose(bool value)
    {
        _imageVictory.LaunchNextLevel();
        Play();
    }

    public void Play()
    {
        _gameStopControl.Play();
    }

    public void Stop()
    {
        _gameStopControl.Stop();
    }
}
