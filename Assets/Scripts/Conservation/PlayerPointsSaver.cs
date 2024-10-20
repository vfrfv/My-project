using Assets.Scripts.Leaderboard;
using Assets.Scripts.Tanks.TankEnemy.Tank.Turret;
using System;
using UnityEngine;

namespace Conservation
{
    [Serializable]
    public class PlayerPointsSaver
    {
        private const string KeySavedPoints = "CurrentPoints";

        [SerializeField] private float _currentPoints;

        private readonly FlightTower _flightTower;

        public PlayerPointsSaver(FlightTower flightTower)
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

        private void Load()
        {
            if (Agava.YandexGames.Utility.PlayerPrefs.HasKey(KeySavedPoints))
            {
                _currentPoints = Agava.YandexGames.Utility.PlayerPrefs.GetFloat(KeySavedPoints);
            }
        }
    }
}