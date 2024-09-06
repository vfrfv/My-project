using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Source.Yandex
{
    public class SDKInitializer : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private const string FirstScene = "Menu";

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private void Start()
        {
            StartCoroutine(Coroutine());
        }

        private IEnumerator Coroutine()
        {
            yield return YandexGamesSdk.Initialize(OnInitialized);
            Agava.YandexGames.Utility.PlayerPrefs.Load();
        }

        private void OnInitialized()
        {
            StartCoroutine(LoadSceneAsync(FirstScene));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncOperation.isDone)
            {
                _slider.value = asyncOperation.progress;

                yield return null;
            }
        }
    }
}


