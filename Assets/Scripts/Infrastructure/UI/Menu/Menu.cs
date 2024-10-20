using Conservation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Infrastructure.UI.Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField]private Button _startButton;
        [SerializeField] private Button _levelsButton;
        [SerializeField] private Button _exitLevelsWindowButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitSettings;

        [SerializeField] private Image _imageLevelsWindow;
        [SerializeField] private Image _imageSettings;

        [SerializeField] private ProgressSaver _progressSaver;

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
#if (UNITY_WEBGL && !UNITY_EDITOR)
        YandexGamesSdk.GameReady();
#endif

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

        private void Play()
        {
            _progressSaver.Load();

            SceneManager.LoadScene(_progressSaver.CurrentLevel);
        }

        private void OpenLevelsWindow()
        {
            _imageLevelsWindow.gameObject.SetActive(true);
        }

        private void ExitLevelsWindow()
        {
            _imageLevelsWindow.gameObject.SetActive(false);
        }

        private void OpenSettings()
        {
            _imageSettings.gameObject.SetActive(true);
        }

        private void ExitSettings()
        {
            _imageSettings.gameObject.SetActive(false);
        }
    }
}