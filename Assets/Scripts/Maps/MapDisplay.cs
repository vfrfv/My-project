using Conservation;
using Manager;
using Maps.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Maps
{
    public class MapDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _mapName;
        [SerializeField] private Image _mapImage;
        [SerializeField] private Button _playBatton;
        [SerializeField] private Image _locImage;
        [SerializeField] private ProgressSaver _progressSaver;
        [SerializeField] private LevelNavigator _levelManager;

        private Map _map;

        public void DisplayMap(Map map)
        {
            _map = map;

            _mapName.text = Lean.Localization.LeanLocalization.GetTranslationText(_map.MapNameKey);
            _mapImage.sprite = _map.MapImage;

            _progressSaver.Load();

            bool mapUnlocked = _progressSaver.CurrentLevel >= _map.MapIndex;
            DisplayExclamationMark(mapUnlocked);
            DarkenMapDisplay(mapUnlocked);

            _playBatton.onClick.RemoveAllListeners();
            _playBatton.onClick.AddListener(OnPlayButtonClick);
        }

        private void OnPlayButtonClick()
        {
            _levelManager.UploadSceneName(_map.NameScene);
        }

        private void DisplayExclamationMark(bool mapUnlocked)
        {
            _locImage.gameObject.SetActive(!mapUnlocked);
            _playBatton.interactable = mapUnlocked;
        }

        private void DarkenMapDisplay(bool mapUnlocked)
        {
            if (mapUnlocked)
                _mapImage.color = Color.white;
            else
                _mapImage.color = Color.gray;
        }
    }
}