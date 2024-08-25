using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Yandex
{
    public class SDKInitializer : MonoBehaviour
    {
        private const string FirstScene = "Menu";

        private void Awake()
        {
            YandexGamesSdk.GameReady();
            YandexGamesSdk.CallbackLogging = true;
        }

        private IEnumerator Start()
        {
            yield return YandexGamesSdk.Initialize(OnInitialized);
        }

        private void OnInitialized()
        {
            SceneManager.LoadScene(FirstScene);
        }
    }
}


