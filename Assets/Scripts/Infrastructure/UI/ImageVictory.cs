using Advertisement;
using System;
using Tanks.TankEnemy.Tank.Turret;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Infrastructure.UI
{
    public class ImageVictory : MonoBehaviour
    {
        private const string KeyTextPoints = "Points";

        [SerializeField] private TMP_Text _textPoints;
        [SerializeField] private TMP_Text _message;
        [SerializeField] private FlightTower _flightTower;
        [SerializeField] private Button _nextLevel;
        [SerializeField] private VideoAd _videoAd;

        private float _currentPoints;

        public event Action Pressed;

        private void OnEnable()
        {
            _videoAd.Looked += AddPointsAfterAd;
            _flightTower.NumberPointsChanged += ShowPoints;
            _nextLevel.onClick.AddListener(RunBeforeChangingScene);
        }

        private void OnDisable()
        {
            _flightTower.NumberPointsChanged -= ShowPoints;
            _videoAd.Looked -= AddPointsAfterAd;
            _nextLevel.onClick.RemoveListener(RunBeforeChangingScene);
        }

        public void ShowPoints(float point)
        {
            _currentPoints = point;
            _textPoints.text = $"{Lean.Localization.LeanLocalization.GetTranslationText(KeyTextPoints)} {_currentPoints.ToString("F0")}";
        }

        public void LaunchNextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                string nextScenePath = SceneUtility.GetScenePathByBuildIndex(nextSceneIndex);
                string nextSceneName = System.IO.Path.GetFileNameWithoutExtension(nextScenePath);

                if (nextSceneName != "Menu")
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
                else
                {
                    SceneManager.LoadScene(1);
                }
            }
            else
            {
                _message.gameObject.SetActive(true);
            }

            Time.timeScale = 1;
        }

        private void RunBeforeChangingScene()
        {
            Pressed?.Invoke();
        }

        private void AddPointsAfterAd(float bonusPoints)
        {
            _currentPoints += bonusPoints;
            _textPoints.text = $"{Lean.Localization.LeanLocalization.GetTranslationText(KeyTextPoints)} {_currentPoints.ToString("F0")}";
        }
    }
}