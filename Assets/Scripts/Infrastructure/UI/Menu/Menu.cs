using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Button _startButton;
    [SerializeField] Button _levelsButton;
    [SerializeField] Button _exitLevelsWindowButton;
    [SerializeField] Button _settingsButton;
    [SerializeField] Button _exitSettings;

    [SerializeField] Image _imageLevelsWindow;
    [SerializeField] Image _imageSettings;

    [SerializeField] LevelManager _levelManager;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(Play);
        _levelsButton.onClick.AddListener(OpenLevelsWindow);
        _exitLevelsWindowButton.onClick.AddListener(ExitLevelsWindow);
        _settingsButton.onClick.AddListener(OpenSettings);
        _exitSettings.onClick.AddListener(ExitSettings);
    }

    private void Awake()
    {
        ExitLevelsWindow();
        ExitSettings();
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(Play);
        _levelsButton.onClick.RemoveListener(OpenLevelsWindow);
        _exitLevelsWindowButton.onClick.RemoveListener(ExitLevelsWindow);
        _settingsButton.onClick.RemoveListener(OpenSettings);
        _exitSettings.onClick.RemoveListener(ExitSettings);
    }

    public void Play()
    {
        _levelManager.Load();

        SceneManager.LoadSceneAsync(_levelManager.CurrentLevel);
    }

    public void OpenLevelsWindow()
    {
        _imageLevelsWindow.gameObject.SetActive(true);
    }

    public void ExitLevelsWindow()
    {
        _imageLevelsWindow.gameObject.SetActive(false);
    }

    public void OpenSettings()
    {
        _imageSettings.gameObject.SetActive(true);
    }

    public void ExitSettings()
    {
        _imageSettings.gameObject.SetActive(false);
    }
}
