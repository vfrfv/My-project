using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapDisplay : MonoBehaviour
{
    private const string Turkish = "tr";
    private const string Russian = "ru";
    private const string English = "en";

    [SerializeField] private TMP_Text _mapName;
    [SerializeField] private Image _mapImage;
    [SerializeField] private Button _playBatton;
    [SerializeField] private Image _locImage;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private Localization _localization;

    private Map _map;

    public void DisplayMap(Map map)
    {
        _map = map;

        _mapName.text = Lean.Localization.LeanLocalization.GetTranslationText(_map.MapNameKey);
        _mapImage.sprite = _map.MapImage;

        _levelManager.Load();

        bool mapUnlocked = _levelManager.CurrentLevel >= _map.MapIndex;
        DisplayExclamationMark(mapUnlocked);
        DarkenMapDisplay(mapUnlocked);

        _playBatton.onClick.RemoveAllListeners();
        _playBatton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnPlayButtonClick()
    {
        SceneManager.LoadScene(_map.NameScene);
    }

    private void DisplayExclamationMark(bool mapUnlocked)
    {
        _locImage.gameObject.SetActive(!mapUnlocked);
        _playBatton.interactable = mapUnlocked;
    }

    private void DarkenMapDisplay(bool mapUnlocked)
    {
        if (mapUnlocked)
            _mapImage.color = UnityEngine.Color.white;
        else
            _mapImage.color = UnityEngine.Color.gray;
    }
}