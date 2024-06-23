using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopService 
{
    // - LevelProgressService
    // - UpgradeService

    // говорит апгейду прокачаться 

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
