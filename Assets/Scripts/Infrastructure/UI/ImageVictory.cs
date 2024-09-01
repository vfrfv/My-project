using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageVictory : MonoBehaviour
{
    private const string KeyTextPoints = "Points";

    [SerializeField] private TMP_Text _textPoints;
    [SerializeField] private TMP_Text _message;
    [SerializeField] private FlightTower _flightTower;
    [SerializeField] private Button _nextLevel;
    [SerializeField] VideoAd _videoAd;

    private float _currentPoints;

    public event Action Pressed;

    private void OnEnable()
    {
        _videoAd.looked += AddPointsAfterAd;
        _flightTower.NumberPointsChanged += ShowPoints;
        _nextLevel.onClick.AddListener(RunBeforeChangingScene);
    }

    private void OnDisable()
    {
        _flightTower.NumberPointsChanged -= ShowPoints;
        _videoAd.looked -= AddPointsAfterAd;
        _nextLevel.onClick.RemoveListener(RunBeforeChangingScene);
    }

    private void Start()
    {
        _message.gameObject.SetActive(false);
    }

    public void ShowPoints(float point)
    {
        _currentPoints = point;
        _textPoints.text = $"{Lean.Localization.LeanLocalization.GetTranslationText(KeyTextPoints)} {_currentPoints.ToString("F0")}";
    }

    public void AddPointsAfterAd(float bonusPoints)
    {
        _currentPoints += bonusPoints; 
        _textPoints.text = $"{Lean.Localization.LeanLocalization.GetTranslationText(KeyTextPoints)} {_currentPoints.ToString("F0")}";
    }

    public void LaunchNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (SceneManager.GetSceneByName ("Menu").buildIndex != nextSceneIndex)
        {
            Debug.Log(SceneManager.GetSceneByBuildIndex(nextSceneIndex).name);

            SceneManager.LoadScene(nextSceneIndex);
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
}
