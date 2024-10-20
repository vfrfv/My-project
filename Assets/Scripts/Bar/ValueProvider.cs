using Infrastructure.Services;
using System;
using UnityEngine;

namespace Bar
{
    public class ValueProvider : MonoBehaviour, IValue
    {
        private PlayerLevelProgressService _playerProgressService;
        private SmoothBar _smoothBar;

        public int Value => _playerProgressService.CurrentCountFrags;

        public int MaxValue => _playerProgressService.CountFragsUpgrade;

        public event Action<int> Changed;

        public void Init(PlayerLevelProgressService levelProgressService, SmoothBar smoothBar)
        {
            _playerProgressService = levelProgressService;
            _smoothBar = smoothBar;

            _playerProgressService.Changed += OnProgressChange;
            _smoothBar.Init(this);
        }

        private void OnProgressChange(int progress)
        {
            Changed?.Invoke(progress);
        }

        private void OnDestroy()
        {
            _playerProgressService.Changed -= OnProgressChange;
        }
    }
}