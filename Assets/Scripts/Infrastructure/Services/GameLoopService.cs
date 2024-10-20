using Assets.Scripts.Tanks.TankEnemy.Tank;
using System;

namespace Infrastructure.Services
{
    public class GameLoopService
    {
        private readonly PlayerLevelProgressService _playerLevelProgressService;
        private readonly UpgradeService _upgradeService;

        public PlayerLevelProgressService LevelProgressService => _playerLevelProgressService;
        public UpgradeService UpgradeService => _upgradeService;

        public GameLoopService(PlayerLevelProgressService levelProgressService,
            UpgradeService upgradeService)
        {
            _playerLevelProgressService = levelProgressService ?? throw new ArgumentNullException(nameof(levelProgressService));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));

            levelProgressService.Improved += OnImproved;
        }

        public void OnEnemiesDie(Enemy enemy)
        {
            enemy.Died += _playerLevelProgressService.AddProgress;
        }

        private void OnImproved()
        {
            _upgradeService.Upgrade();
        }
    }
}