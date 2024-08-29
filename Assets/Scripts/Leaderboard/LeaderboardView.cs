using Agava.YandexGames;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private LeaderboardElement _leaderboardElementPrefab;

    [SerializeField] private Image _imageAuthorizations;
    [SerializeField] private Image _imageAuthorizationError;

    [SerializeField] private Button _buttonAuthorization;
    [SerializeField] private Button _buttonClosingAuthorization;
    [SerializeField] private Button _buttonAuthorizationError;

    private List<LeaderboardElement> _spawnedElements = new List<LeaderboardElement>();
    public Action _onSuccess;
    public Action<string> _onError;

    public event Action Logged;


    private void Awake()
    {
        CloseAuthorizationWindow();
        CloseErrorWindow();
    }

    private void OnEnable()
    {
        _buttonAuthorization.onClick.AddListener(Authorize);
        _buttonClosingAuthorization.onClick.AddListener(CloseAuthorizationWindow);
        _buttonAuthorizationError.onClick.AddListener(CloseErrorWindow);
    }

    private void OnDisable()
    {
        _buttonAuthorization.onClick.RemoveListener(Authorize);
        _buttonClosingAuthorization.onClick.RemoveListener(CloseAuthorizationWindow);
        _buttonAuthorizationError.onClick.RemoveListener(CloseErrorWindow);
    }

    public void ConstructLeaderboard(List<LeaderboardPlayer> leaderboardPlayers)
    {
        ClearLeaderboard();

        foreach (var player in leaderboardPlayers)
        {
            LeaderboardElement leaderboardElementInstance = Instantiate(_leaderboardElementPrefab, _container);
            leaderboardElementInstance.Initialize(player.Name, player.Rank, player.Score);

            _spawnedElements.Add(leaderboardElementInstance);
        }
    }

    public void OpenAuthorizationWindow(Action onSuccess, Action<string> onError)
    {
        _onSuccess = onSuccess;
        _onError = onError;

        _imageAuthorizations.gameObject.SetActive(true);
    }

    public void CloseAuthorizationWindow()
    {
        _imageAuthorizations.gameObject.SetActive(false);

        _onError?.Invoke("0");
    }

    public void OpenErrorWindow()
    {
        _imageAuthorizationError.gameObject.SetActive(true);
    }

    private void CloseErrorWindow()
    {
        _imageAuthorizationError.gameObject.SetActive(false);
    }

    public void OpenLeaderboard()
    {
        this.gameObject.SetActive(true);
    }

    public void CloseLeaderboard()
    {
        this.gameObject.SetActive(false);
    }

    private void ClearLeaderboard()
    {
        foreach (var element in _spawnedElements)
        {
            Destroy(element.gameObject);
        }

        _spawnedElements.Clear();
    }

    private void Authorize()
    {
        PlayerAccount.Authorize(_onSuccess, _onError);

        CloseAuthorizationWindow();
    }
}
