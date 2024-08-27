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
        // ������ ����������� �������� �����
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // Coroutine ��� �������� �����
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // ������ ����������� �������� �����
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        // ��������� �������������� ��������� �����, ���� ����� ������ ���-�� �� ���������
        asyncOperation.allowSceneActivation = false;

        // ����, ������� ����� ��������� �������� ��������
        while (!asyncOperation.isDone)
        {
            // �������� �������� (�� 0 �� 1)
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            // �������� ���������� �������� (���� �������� ������ 90%)
            if (asyncOperation.progress >= 0.9f)
            {
                Debug.Log("Press any key to continue...");

                // ���� ������� ������� ��� ��������� �����
                if (Input.anyKeyDown)
                {
                    // ��������� ��������� �����
                    asyncOperation.allowSceneActivation = true;
                }
            }

            // ���� ��������� ����
            yield return null;
        }
    }
}
