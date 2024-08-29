using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UILevel : MonoBehaviour
{
    [SerializeField] private GameObject _imageDefeat;
    [SerializeField] private GameObject _imageVictory;
    [SerializeField] private Player _player;
    [SerializeField] private FlightTower _flightTower;

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button[] _menuButtons;
    [SerializeField] private ImageVictory _image;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(Restart);

        foreach (var button in _menuButtons)
        {
            button.onClick.AddListener(ExitInMenu);
        }
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(Restart);

        foreach (var button in _menuButtons)
        {
            button.onClick.RemoveListener(ExitInMenu);
        }

        _player.Died -= ShowDefeatWindow;
        _flightTower.AchievedGoal += ShowVictoryWindow;
        _flightTower.NumberPointsChanged -= ShowVictoryWindow;
    }

    private void Start()
    {
        _imageDefeat.SetActive(false);
        _imageVictory.SetActive(false);

        _player.Died += ShowDefeatWindow;
        _flightTower.AchievedGoal += ShowVictoryWindow;
        _flightTower.NumberPointsChanged += ShowVictoryWindow;
    }

    private void ShowDefeatWindow()
    {
        Time.timeScale = 0;
        _imageDefeat.SetActive(true);
    }

    private void ShowVictoryWindow(float point)
    {
        StartCoroutine(DelayBeforeShowing(point));
    }

    private IEnumerator DelayBeforeShowing(float point)
    {
        yield return new WaitForSeconds(2);

        _imageVictory.SetActive(true);
        _image.ShowPoints(point);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void ExitInMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
