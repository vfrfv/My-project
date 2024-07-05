using System;
using System.Collections.Generic;

public class GameLoopService // —ервис игрового цикла, отвечает за логику уровн€
{
    private LevelProgressService _levelProgressService;
    private UpgradeService _upgradeService;
    private ZoneService _zoneService;

    private List<Enemy> _enemies = new List<Enemy>();
    private Barrier _barrier;

    public GameLoopService(List<Enemy> enemies, LevelProgressService levelProgressService, UpgradeService upgradeService, ZoneService zoneService, Barrier barrier)
    {
        _levelProgressService = levelProgressService ?? throw new ArgumentNullException(nameof(levelProgressService));
        _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
        _zoneService = zoneService ?? throw new ArgumentNullException(nameof(zoneService));
        _enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
        _barrier = barrier ?? throw new ArgumentNullException(nameof(barrier));

        OnEnemiesDie();
        levelProgressService.Improved += OnImproved;
        zoneService.MovedNextZone += OpenNextZone;
    }

    ~GameLoopService() // диструктор, вызываетс€ 
    {

    }

    public void OnEnemiesDie()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Died += _levelProgressService.AddProgress;
            enemy.Died += _zoneService.AddProgress;
        }
    }

    private void OnImproved()
    {
        _upgradeService.Upgrade();
    }

    private void OpenNextZone()
    {
        _barrier.OpenZone();
    }

    private void Dispose()
    {
        // посмотреть на метаните
    }
}
