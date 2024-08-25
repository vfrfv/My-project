using Agava.YandexGames;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageVictory : MonoBehaviour
{
    private const string MesajRU = "Начислено очков ";
    private const string MesajEU = "Points awarded ";
    private const string MesajTR = "Puan verildi ";
    private const string Turkish = "tr";
    private const string Russian = "ru";
    private const string English = "en";

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

    private void Awake()
    {
        _languageCode = YandexGamesSdk.Environment.i18n.lang;
    }

    private void Start()
    {
        _message.gameObject.SetActive(false);
    }

    private void ShowPoints(float point)
    {
        switch (_languageCode)
        {
            case English:
                _textPoints.text = MesajEU + point.ToString("F0");
                break;

            case Turkish:
                _textPoints.text = MesajTR + point.ToString("F0");
                break;

            case Russian:
                _textPoints.text = MesajRU + point.ToString("F0");
                break;
        }
    }

    private void LaunchNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex++;

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
