using Conservation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Infrastructure.UI.Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] Button _startButton;
        [SerializeField] Button _levelsButton;
        [SerializeField] Button _exitLevelsWindowButton;
        [SerializeField] Button _settingsButton;
        [SerializeField] Button _exitSettings;

        [SerializeField] Image _imageLevelsWindow;
        [SerializeField] Image _imageSettings;

        [SerializeField] ProgressSaver _progressSaver;

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

        public void Play()
        {
            _progressSaver.Load();

            SceneManager.LoadScene(_progressSaver.CurrentLevel);
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
}