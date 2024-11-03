using Manager;
using System.Collections;
using Tanks.TankEnemy.Turret;
using Tanks.TankPlayer;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.UI
{
    public class UILevel : MonoBehaviour
    {
        [SerializeField] private Image _imageDefeat;
        [SerializeField] private Image _imageVictory;
        [SerializeField] private Player _player;
        [SerializeField] private FlightTower _flightTower;
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button[] _menuButtons;
        [SerializeField] private VictoryPanel _image;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(_levelManager.Restart);

            foreach (var button in _menuButtons)
            {
                button.onClick.AddListener(_levelManager.ExitInMenu);
            }
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(_levelManager.Restart);

            foreach (var button in _menuButtons)
            {
                button.onClick.RemoveListener(_levelManager.ExitInMenu);
            }

            _player.Died -= ShowDefeatWindow;
            _flightTower.AchievedGoal += ShowVictoryWindow;
            _flightTower.NumberPointsChanged -= ShowVictoryWindow;
        }

        private void Start()
        {
            _imageDefeat.gameObject.SetActive(false);
            _imageVictory.gameObject.SetActive(false);

            _player.Died += ShowDefeatWindow;
            _flightTower.AchievedGoal += ShowVictoryWindow;
            _flightTower.NumberPointsChanged += ShowVictoryWindow;
        }

        private void ShowDefeatWindow()
        {
            Time.timeScale = 0;
            _imageDefeat.gameObject.SetActive(true);
        }

        private void ShowVictoryWindow(float point)
        {
            StartCoroutine(DelayBeforeShowing(point));
        }

        private IEnumerator DelayBeforeShowing(float point)
        {
            yield return new WaitForSeconds(2);

            _imageVictory.gameObject.SetActive(true);
            _image.ShowPoints(point);
        }
    }
}