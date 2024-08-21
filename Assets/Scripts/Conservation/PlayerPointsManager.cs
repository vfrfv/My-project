using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPointsManager
{
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

        PlayerPrefs.SetFloat("CurrentPoints", _currentPoints);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("CurrentPoints"))
        {
            _currentPoints = PlayerPrefs.GetFloat("CurrentPoints");
        }
    }

    public void SetDefolt()
    {
        PlayerPrefs.SetFloat("CurrentPoints", 0);
        PlayerPrefs.Save();
    }
}
