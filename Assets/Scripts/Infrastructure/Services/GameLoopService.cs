using System;
using Tanks.TankEnemy;

namespace Infrastructure.Services
{
    public class GameLoopService
    {
        private readonly PlayerLevelProgressService _playerLevelProgressService;
        private readonly UpgradeService _upgradeService;

        public GameLoopService(PlayerLevelProgressService levelProgressService,
            UpgradeService upgradeService)
        {
            _playerLevelProgressService = levelProgressService ?? throw new ArgumentNullException(nameof(levelProgressService));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));

            levelProgressService.Improved += OnImproved;
        }

        public void AddPlayerProgress(Enemy enemy)
        {
            enemy.Died += _playerLevelProgressService.AddProgress;
        }

        private void OnImproved()
        {
            _upgradeService.Upgrade();
        }
    }
}