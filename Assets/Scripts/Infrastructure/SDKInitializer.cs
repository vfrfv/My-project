using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Yandex
{
    public class SDKInitializer : MonoBehaviour
    {
        [SerializeField] private LevelManager _levelManager;

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
        }

        private void OnInitialized()
        {
            SceneManager.LoadScene(FirstScene);

        }
    }
}


