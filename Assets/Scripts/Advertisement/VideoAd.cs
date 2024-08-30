using UnityEngine;
using UnityEngine.UI;

public class VideoAd : MonoBehaviour
{
    [SerializeField] private Button _advertisement;
    [SerializeField] private PlayerPointsManager _playerPointsManager;
    [SerializeField] private GameStopControl _gameStopControl;

    private float _points = 50;

    private void Awake()
    {
        _advertisement.onClick.AddListener(Show);
    }

    private void OnDisable()
    {
        _advertisement.onClick.RemoveListener(Show);
    }

    public void Show()
    {
        Agava.YandexGames.VideoAd.Show(_gameStopControl.Stop, OnRewardCallback, _gameStopControl.Play);
    }

    private void OnRewardCallback()
    {
        _playerPointsManager.AddPoints(_points);
    }  
}
