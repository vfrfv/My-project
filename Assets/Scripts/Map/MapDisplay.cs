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

    public void DisplayMap(Map map)
    {
        _mapName.text = map.MapName;
        _mapImage.sprite = map.MapImage;

        bool mapUnlocked = PlayerPrefs.GetInt("currentScene", 0) >= map.MapIndex;

        //_locImage.gameObject.SetActive(!mapUnlocked);
        //_playBatton.interactable = mapUnlocked;

        //if (mapUnlocked)
        //    _mapImage.color = Color.white;
        //else
        //    _mapImage.color = Color.gray;

        _playBatton.onClick.RemoveAllListeners();
        _playBatton.onClick.AddListener(() => SceneManager.LoadScene(map.SceneToLoad.name));
    }
}
