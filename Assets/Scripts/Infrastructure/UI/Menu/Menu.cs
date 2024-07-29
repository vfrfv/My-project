using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Button _startButton;
    [SerializeField] Button _levelsButton;
    [SerializeField] Button _exitLevelsWindowButton;

    [SerializeField] Image _levelsWindow;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(Play);
        _levelsButton.onClick.AddListener(OpenLevelsWindow);
        _exitLevelsWindowButton.onClick.AddListener(ExitLevelsWindow);
    }

    private void Awake()
    {
        ExitLevelsWindow();
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(Play);
        _levelsButton.onClick.RemoveListener(OpenLevelsWindow);
        _exitLevelsWindowButton.onClick.RemoveListener(ExitLevelsWindow);
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OpenLevelsWindow()
    {
        _levelsWindow.gameObject.SetActive(true);
    }

    public void ExitLevelsWindow()
    {
        _levelsWindow.gameObject.SetActive(false);
    }
}
