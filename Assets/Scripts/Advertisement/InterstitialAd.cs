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
        Time.timeScale = 1;
        AudioListener.volume = 1;
        //_mixerGroup.audioMixer.SetFloat("Master", -80);
    }

    public void Stop()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;
        //_mixerGroup.audioMixer.SetFloat("Master", 0);
    }
}
