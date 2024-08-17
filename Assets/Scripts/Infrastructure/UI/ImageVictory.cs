using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageVictory : MonoBehaviour
{
    [SerializeField] private TMP_Text _textPoints;
    [SerializeField] private TMP_Text _message;
    [SerializeField] private FlightTower _flightTower;
    [SerializeField] private Button _nextLevel;

    private void OnEnable()
    {
        _nextLevel.onClick.AddListener(LaunchNextLevel);
    }

    private void OnDisable()
    {
        _nextLevel.onClick.RemoveListener(LaunchNextLevel);
    }

    private void Start()
    {
        _flightTower.NumberPointsChanged += ShowPoints;
        _message.gameObject.SetActive(false);
    }

    private void ShowPoints(float point)
    {
        _textPoints.text = $"Начислено {point.ToString("F0")} очков";
    }

    private void LaunchNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            _message.gameObject.SetActive(true);
            _message.text = "В разработке";
        }

        Time.timeScale = 1;
    }
}
