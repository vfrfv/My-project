using System;
using Tanks.TankEnemy;

namespace Infrastructure.Services
{
    public class PlayerLevelProgressService
    {
        private readonly int _countFragsUpgrade = 4;
        private readonly UpgradeService _upgradeService;
        private int _currentCountFrags = 0;

        public PlayerLevelProgressService(UpgradeService upgradeService)
        {
            _upgradeService = upgradeService;
        }

        public int CurrentCountFrags => _currentCountFrags;
        public int CountFragsUpgrade => _countFragsUpgrade;

        public event Action Improved;
        public event Action<int> Changed;

        public void AddProgress(Enemy _)
        {
            _currentCountFrags++;

            if (_currentCountFrags >= _countFragsUpgrade)
            {
                Improved?.Invoke();
                _currentCountFrags = 0;
            }

            if (_upgradeService.IsMaxLevel())
            {
                Changed?.Invoke(_countFragsUpgrade);
            }
            else
            {
                Changed?.Invoke(_currentCountFrags);
            }
        }
    }
}