using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageVictory : MonoBehaviour
{
    private const string _mesajRU = "Начислено очков ";
    private const string _mesajEU = "Points awarded ";
    private const string _mesajTR = "Puan verildi ";

    [SerializeField] private TMP_Text _textPoints;
    [SerializeField] private TMP_Text _message;
    [SerializeField] private FlightTower _flightTower;
    [SerializeField] private Button _nextLevel;

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

    private void ShowPoints(float point)
    {
        _textPoints.text = _mesajRU + point.ToString("F0");
    }

    private void LaunchNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex ++;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            _message.gameObject.SetActive(true);
        }

        Time.timeScale = 1;
    }
}
