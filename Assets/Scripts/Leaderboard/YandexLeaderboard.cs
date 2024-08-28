using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YandexLeaderboard : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard";
    private const string AnonymousName = "Anonymous";

    private LoggingServis _loggingServis;

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new List<LeaderboardPlayer>();

    [SerializeField] private LeaderboardView _leaderboardView;
    [SerializeField] private Button _buttonLeaderboard;

    private void Awake()
    {
        _loggingServis = new LoggingServis();
    }

    private void OnEnable()
    {
        _buttonLeaderboard.onClick.AddListener(OpenLeaderboard);

        _leaderboardView.Logged += Log;
        _loggingServis.LogSuccess += LogSuccess;
        _loggingServis.LogError += LogError;
    }

    private void OnDisable()
    {
        _buttonLeaderboard.onClick.RemoveListener(OpenLeaderboard);

        _leaderboardView.Logged -= Log;
        _loggingServis.LogSuccess -= LogSuccess;
        _loggingServis.LogError -= LogError;
    }

    //public void SetPlayerScore(int score)
    //{
    //    if (_loggingServis.IsLogged == false)
    //    {
    //        return;
    //    }

    //    Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
    //    {
    //        if (result == null || result.score < score)
    //            Leaderboard.SetScore(LeaderboardName, score);
    //    });
    //}

    public void Fill()
    {
        if (PlayerAccount.IsAuthorized == false)
        {
            return;
        }

        _leaderboardPlayers.Clear();

        Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            foreach (var entry in result.entries)
            {
                int rank = entry.rank;
                int score = entry.score;
                string name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = AnonymousName;

                _leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));
            }

            _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
        });
    }

    private void LogSuccess()
    {
        Fill();
        _leaderboardView.OpenLeaderboard();
    }

    private void LogError(string message)
    {
        _leaderboardView.CloseAuthorizationWindow();
        _leaderboardView.OpenErrorWindow();
    }

    private void OpenLeaderboard()
    {
        if (_loggingServis.IsLogged == false)
        {
            _leaderboardView.OpenAuthorizationWindow();
        }

        _leaderboardView.OpenLeaderboard();
    }

    private void Log()
    {
        _loggingServis.Log();
    }
}
