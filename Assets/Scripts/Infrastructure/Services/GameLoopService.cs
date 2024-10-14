using System;

public class GameLoopService
{
    private LevelProgressService _levelProgressService;
    private UpgradeService _upgradeService;

    public LevelProgressService LevelProgressService => _levelProgressService;
    public UpgradeService UpgradeService => _upgradeService;

    public GameLoopService(LevelProgressService levelProgressService,
        UpgradeService upgradeService)
    {
        _levelProgressService = levelProgressService ?? throw new ArgumentNullException(nameof(levelProgressService));
        _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));

        levelProgressService.Improved += OnImproved;
    }

    public void OnEnemiesDie(Enemy enemy)
    {
        enemy.Died += _levelProgressService.AddProgress;
    }

    private void OnImproved()
    {
        _upgradeService.Upgrade();
    }
}