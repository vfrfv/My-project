using GLTF.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UILevel : MonoBehaviour
{
    [SerializeField] private GameObject _imageDefeat;
    [SerializeField] private GameObject _imageVictory;
    [SerializeField] private Player _player;
    [SerializeField] private FlightTower _flightTower;

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(Restart);
        _menuButton.onClick.AddListener(ExitInMenu);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(Restart);
        _menuButton.onClick.RemoveListener(ExitInMenu);

        _player.Died -= ShowDefeatWindow;
        _flightTower.AchievedGoal += ShowVictoryWindow;
    }

    private void Start()
    {
       _imageDefeat.SetActive(false);
        _imageVictory.SetActive(false);

        _player.Died += ShowDefeatWindow;
        _flightTower.AchievedGoal += ShowVictoryWindow;
    }

    private void ShowDefeatWindow()
    {
        Time.timeScale = 0;
        _imageDefeat.SetActive(true);
    }

    private void ShowVictoryWindow()
    {
        StartCoroutine(DelayBeforeShowing());
    }

    private IEnumerator DelayBeforeShowing()
    {
        yield return new WaitForSeconds(2);

        _imageVictory.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void ExitInMenu()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
}
