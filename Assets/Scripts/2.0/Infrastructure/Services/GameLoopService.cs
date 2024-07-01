using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopService // —ервис игрового цикла, отвечает за логику уровн€
{
    // следит за смертию врагов, при смерти вызывает AddProgress 

    // - LevelProgressService
    // - UpgradeService

    // говорит апгейду прокачатьс€ 

    private LevelProgressService _levelProgressService;
    private UpgradeService _upgradeService;

    public GameLoopService(LevelProgressService levelProgressService, UpgradeService upgradeService)
    {
        _levelProgressService = levelProgressService ?? throw new ArgumentNullException(nameof(levelProgressService));
        _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));

        levelProgressService.Improved += OnImproved;
    }

    private void OnImproved()
    {
        _upgradeService.Upgrade();
    }

    private void Dispose()
    {

    }
}
