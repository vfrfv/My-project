using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Infrastructure
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {
                float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

                if (asyncOperation.progress >= 0.9f)
                {
                    if (Input.anyKeyDown)
                    {
                        asyncOperation.allowSceneActivation = true;
                    }
                }

                yield return null;
            }
        }
    }
}