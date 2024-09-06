using System;
using UnityEngine;

[Serializable]
public class PlayerPointsManager
{
    private const string KeySavedPoints = "CurrentPoints";

    [SerializeField] private float _currentPoints;

    private FlightTower _flightTower;

    public PlayerPointsManager(FlightTower flightTower)
    {
        _flightTower = flightTower ?? throw new ArgumentNullException(nameof(flightTower));

        Load();

        _flightTower.PointsTransferredPlayer += AddPoints;
    }

    public float CurrentPoints => _currentPoints;

    public event Action<int> IsPointsAwarded;

    public void AddPoints(float points)
    {
        float anInteger = (float)Math.Truncate(points);
        Load();
        _currentPoints += anInteger;

        IsPointsAwarded?.Invoke((int)_currentPoints);

        Agava.YandexGames.Utility.PlayerPrefs.SetFloat(KeySavedPoints, _currentPoints);
        Agava.YandexGames.Utility.PlayerPrefs.Save();
        Agava.YandexGames.Leaderboard.SetScore(Constants.LEADERBOARD_NAME, (int)_currentPoints);
    }

    public void Load()
    {
        if (Agava.YandexGames.Utility.PlayerPrefs.HasKey(KeySavedPoints))
        {
            _currentPoints = Agava.YandexGames.Utility.PlayerPrefs.GetFloat(KeySavedPoints);
        }
    }

    public void SetDefolt()
    {
        PlayerPrefs.SetFloat(KeySavedPoints, 0);
        PlayerPrefs.Save();
    }
}
