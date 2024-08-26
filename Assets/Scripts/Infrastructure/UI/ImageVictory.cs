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

    private string _languageCode;

    private void OnEnable()
    {
        _flightTower.NumberPointsChanged += ShowPoints;
        _nextLevel.onClick.AddListener(LaunchNextLevel);
    }

    private void OnDisable()
    {
        _flightTower.NumberPointsChanged -= ShowPoints;
        _nextLevel.onClick.RemoveListener(LaunchNextLevel);
    }

    private void Start()
    {
        _message.gameObject.SetActive(false);
    }

    public void ShowPoints(float point)
    {
        _textPoints.text = $"{Lean.Localization.LeanLocalization.GetTranslationText(KeyTextPoints)} {point.ToString("F0")}";
    }

    private void LaunchNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex++;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Запускаю" + nextSceneIndex + "сцену");

            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            _message.gameObject.SetActive(true);
        }

        Time.timeScale = 1;
    }
}
