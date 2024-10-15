using Assets.Scripts.Tanks.TankEnemy.Tank.Turret;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class ScoringPoints : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private FlightTower _flightTower;

        private void Start()
        {
            _flightTower.Flew += StartAddPoints;
            _flightTower.NumberPointsChanged += ChengPointsValue;
            _text.enabled = false;
        }

        private void OnDestroy()
        {
            _flightTower.Flew -= StartAddPoints;
            _flightTower.NumberPointsChanged -= ChengPointsValue;
        }

        private void StartAddPoints()
        {
            _text.enabled = true;
        }

        private void ChengPointsValue(float value)
        {
            _text.text = value.ToString("F0");
        }
    }
}