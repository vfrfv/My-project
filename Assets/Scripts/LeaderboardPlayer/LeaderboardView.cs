using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LeaderboardPlayer
{
    public class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private Transform _mainContainer;
        [SerializeField] private Transform _playerEntryContainer;
        [SerializeField] private Button _closeButton;
        [SerializeField] private LeaderboardEntryView _leaderboardEntryViewPrefab;

        private List<LeaderboardEntryView> _leaderboardEntryViewInstances = new();
        private LeaderboardEntryView _leaderboardPlayerViewInstance;

        private void Awake() => _closeButton.onClick.AddListener(Hide);
        private void OnDestroy() => _closeButton.onClick.RemoveListener(Hide);

        public void ConstructEntries(List<LeaderboardEntryData> entryDatas)
        {
            ClearEntries();

            foreach (LeaderboardEntryData entryData in entryDatas)
            {
                LeaderboardEntryView entryView = Instantiate(_leaderboardEntryViewPrefab, _mainContainer);
                entryView.Initialize(entryData);

                _leaderboardEntryViewInstances.Add(entryView);
            }
        }

        public void ConstructPlayerInfo(LeaderboardEntryData entryData)
        {
            ClearPlayerEntry();

            LeaderboardEntryView entryView = Instantiate(_leaderboardEntryViewPrefab, _playerEntryContainer);
            entryView.Initialize(entryData);

            _leaderboardPlayerViewInstance = entryView;
        }

        public void Show() => gameObject.SetActive(true);
        private void Hide() => gameObject.SetActive(false);

        private void ClearEntries()
        {
            foreach (LeaderboardEntryView leaderboardEntryView in _leaderboardEntryViewInstances)
                Destroy(leaderboardEntryView.gameObject);

            _leaderboardEntryViewInstances.Clear();
        }

        private void ClearPlayerEntry()
        {
            if (_leaderboardPlayerViewInstance == null)
                return;

            Destroy(_leaderboardPlayerViewInstance.gameObject);
            _leaderboardPlayerViewInstance = null;
        }
    }
}