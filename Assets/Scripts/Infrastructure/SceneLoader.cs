using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void LoadScene(string sceneName)
    {
        // Запуск асинхронной загрузки сцены
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // Coroutine для загрузки сцены
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Начало асинхронной загрузки сцены
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        // Запрещаем автоматическую активацию сцены, если нужно делать что-то до активации
        asyncOperation.allowSceneActivation = false;

        // Цикл, который будет проверять прогресс загрузки
        while (!asyncOperation.isDone)
        {
            // Прогресс загрузки (от 0 до 1)
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            // Проверка завершения загрузки (если прогресс достиг 90%)
            if (asyncOperation.progress >= 0.9f)
            {
                Debug.Log("Press any key to continue...");

                // Ждем нажатия клавиши для активации сцены
                if (Input.anyKeyDown)
                {
                    // Разрешаем активацию сцены
                    asyncOperation.allowSceneActivation = true;
                }
            }

            // Ждем следующий кадр
            yield return null;
        }
    }
}
