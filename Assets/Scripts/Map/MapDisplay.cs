using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _mapName;
    [SerializeField] private Image _mapImage;
    [SerializeField] private Button _playBatton;
    [SerializeField] private Image _locImage;
    [SerializeField] private LevelManager _levelManager;

    private Map _map;

    public void DisplayMap(Map map)
    {
        _map = map;

        _mapName.text = map.MapName;
        _mapImage.sprite = map.MapImage;

        bool mapUnlocked = _levelManager.CurrentLevel >= _map.MapIndex;

        Debug.Log($"{_levelManager.CurrentLevel} { _map.MapIndex}");

        _locImage.gameObject.SetActive(!mapUnlocked);
        _playBatton.interactable = mapUnlocked;

        if (mapUnlocked)
            _mapImage.color = Color.white;
        else
            _mapImage.color = Color.gray;

        _playBatton.onClick.RemoveAllListeners();

        _playBatton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnPlayButtonClick()
    {
        SceneManager.LoadScene(_map.NameScene);
    }
}
