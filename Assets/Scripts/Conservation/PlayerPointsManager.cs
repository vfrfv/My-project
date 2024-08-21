using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPointsManager
{
    private const string KeySavedPoints = "CurrentPoints";

    private FlightTower _flightTower;
    private float _currentPoints;

    public PlayerPointsManager(FlightTower flightTower)
    {
        _flightTower = flightTower ?? throw new ArgumentNullException(nameof(flightTower));

        Load();

        _flightTower.PointsTransferredPlayer += AddPoints;
    }

    public float CurrentPoints => _currentPoints;

    private void AddPoints(float points)
    {
        float anInteger = (float)Math.Truncate(points);
        _currentPoints += anInteger;

        PlayerPrefs.SetFloat(KeySavedPoints, _currentPoints);
        PlayerPrefs.Save();
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
}
