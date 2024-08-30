using Agava.YandexGames;
using System;
using UnityEngine;

[Serializable]
public class PlayerPointsManager
{
    private const string LeaderboardName = "Leaderboard";
    private const string KeySavedPoints = "CurrentPoints";

    [SerializeField] private float _currentPoints;

    private FlightTower _flightTower;
    private LoggingServis _loggingServis;

    public PlayerPointsManager(FlightTower flightTower)
    {
        _flightTower = flightTower ?? throw new ArgumentNullException(nameof(flightTower));
        _loggingServis = new LoggingServis();

        Load();

        _flightTower.PointsTransferredPlayer += AddPoints;
    }

    public float CurrentPoints => _currentPoints;

    public event Action<int> IsPointsAwarded;

    public void AddPoints(float points)
    {
        float anInteger = (float)Math.Truncate(points);
        _currentPoints += anInteger;

        SetPlayerScore((int)_currentPoints);

        IsPointsAwarded?.Invoke((int)_currentPoints);

        PlayerPrefs.SetFloat(KeySavedPoints, _currentPoints);
        PlayerPrefs.Save();

        _flightTower.PointsTransferredPlayer -= AddPoints;
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(KeySavedPoints))
        {
            _currentPoints = PlayerPrefs.GetFloat(KeySavedPoints);
        }
    }

    public void SetDefolt()
    {
        PlayerPrefs.SetFloat(KeySavedPoints, 0);
        PlayerPrefs.Save();
    }

    public void SetPlayerScore(int score)
    {
        if (_loggingServis.IsLogged == false)
        {
            return;
        }

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result == null || result.score < score)
                Leaderboard.SetScore(LeaderboardName, score);
        });
    }
}
