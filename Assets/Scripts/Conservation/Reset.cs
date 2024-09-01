using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    [SerializeField] private Button _button;

    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private PlayerPointsManager _playerPointsManager;

    private void OnEnable()
    {
        _button.onClick.AddListener(ThrowOff);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ThrowOff);
    }

    private void ThrowOff()
    {
        _levelManager.SetDefolt();
        _playerPointsManager.SetDefolt();
        PlayerPrefs.DeleteKey("TrainingCompleted");

    }
}
