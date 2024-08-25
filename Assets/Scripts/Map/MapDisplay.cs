using Agava.YandexGames;
using System.Drawing;
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

    private string _languageCode;
    private Map _map;

    private void Awake()
    {
        _languageCode = YandexGamesSdk.Environment.i18n.lang;
    }

    public void DisplayMap(Map map)
    {
        _map = map;

        TranslateText();
        _mapImage.sprite = _map.MapImage;

        _levelManager.Load();

        bool mapUnlocked = _levelManager.CurrentLevel >= _map.MapIndex;

        _locImage.gameObject.SetActive(!mapUnlocked);
        _playBatton.interactable = mapUnlocked;

        if (mapUnlocked)
            _mapImage.color = UnityEngine.Color.white;
        else
            _mapImage.color = UnityEngine.Color.gray;

        _playBatton.onClick.RemoveAllListeners();

        _playBatton.onClick.AddListener(OnPlayButtonClick);
    }

    private void TranslateText()
    {
        switch (_languageCode)
        {
            case English:
                _mapName.text = _map.MapNameEU;
                break;

            case Turkish:
                _mapName.text = _map.MapNameTR;
                break;

            case Russian:
                _mapName.text = _map.MapNameRU;
                break;
        }
    }

    private void OnPlayButtonClick()
    {
        SceneManager.LoadScene(_map.NameScene);
    }
}
