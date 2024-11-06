using Advertisement;
using Agava.WebUtility;
using UnityEngine;

namespace Manager
{
    public class FocusObserver : MonoBehaviour
    {
        private const string Focus = "focus";

        [SerializeField] private PauseHandler _pauseManager;

        private void OnEnable()
        {
            Application.focusChanged += OnInBackgroundChangeApp;
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
        }

        private void OnDisable()
        {
            Application.focusChanged -= OnInBackgroundChangeApp;
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
        }

        private void OnInBackgroundChangeApp(bool inApp)
        {
            PauseGame(!inApp);
        }

        private void OnInBackgroundChangeWeb(bool isBackground)
        {
            PauseGame(isBackground);
        }

        private void PauseGame(bool value)
        {
            if (value)
            {
                _pauseManager.Stop(new PauseSource(Focus));
            }
            else
            {
                _pauseManager.Play(new PauseSource(Focus));
            }
        }
    }
}