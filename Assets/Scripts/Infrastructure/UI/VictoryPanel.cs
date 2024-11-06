using Manager;
using System;
using Tanks.TankEnemy.Turret;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.UI
{
    public class VictoryPanel : MonoBehaviour
    {
        private const string KeyTextPoints = "Points";

        [SerializeField] private TMP_Text _textPoints;
        [SerializeField] private FlightTower _flightTower;
        [SerializeField] private Button _nextLevel;
        [SerializeField] private LevelManager _levelManager;

        public event Action Pressed;

        private void OnEnable()
        {
            _flightTower.NumberPointsChanged += ShowPoints;
            _nextLevel.onClick.AddListener(RunBeforeChangingScene);
        }

        private void OnDisable()
        {
            _flightTower.NumberPointsChanged -= ShowPoints;
            _nextLevel.onClick.RemoveListener(RunBeforeChangingScene);
        }

        public void UpdatePointsText(float points)
        {
            _textPoints.text = $"{Lean.Localization.LeanLocalization.GetTranslationText(KeyTextPoints)} {points.ToString("F0")}";
        }

        public void ShowPoints(float point)
        {
            _textPoints.text = $"{Lean.Localization.LeanLocalization.GetTranslationText(KeyTextPoints)} {point.ToString("F0")}";
        }

        private void RunBeforeChangingScene()
        {
            Pressed?.Invoke();
            _levelManager.LoadNextLevel();
        }
    }
}