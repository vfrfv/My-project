using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YandexLeaderboard : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard";
    private const string AnonymousName = "Anonymous";

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new List<LeaderboardPlayer>();

    [SerializeField] private LeaderboardView _leaderboardView;
    [SerializeField] private Button _buttonLeaderboard;

    private void OnEnable()
    {
        _buttonLeaderboard.onClick.AddListener(OpenLeaderboard);
    }

    private void OnDisable()
    {
        _buttonLeaderboard.onClick.RemoveListener(OpenLeaderboard);
    }

    public void Fill()
    {
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

    private void OnAuthorizeSuccess()
    {
        PlayerAccount.RequestPersonalProfileDataPermission(OnPermissionDataSuccess, OnPermissionDataError);
    }

    private void OnAuthorizeError(string message)
    {
        _leaderboardView.CloseAuthorizationWindow();
        _leaderboardView.OpenErrorWindow();
    }

    private void OpenLeaderboard()
    {
        if(PlayerAccount.IsAuthorized == false)
        {
            _leaderboardView.OpenAuthorizationWindow(OnAuthorizeSuccess, OnAuthorizeError);
        }
        else
        {
            OnAuthorizeSuccess();
        }
    }

    private void OnPermissionDataSuccess()
    {
        Fill();
    }

    private void OnPermissionDataError(string massage)
    {
        Fill();
    }
}
