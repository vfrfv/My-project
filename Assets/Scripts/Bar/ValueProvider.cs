using System;
using UnityEngine;

public class ValueProvider : MonoBehaviour, IValue
{
    private LevelProgressService _progressService;
    private SmoothBar _smoothBar;

    public int Value => _progressService.KilledOpponents;

    public int MaxValue => _progressService.NumberFragsUpgrade;

    public event Action<int> Changed;

    public void Init(LevelProgressService levelProgressService, SmoothBar smoothBar)
    {
        _progressService = levelProgressService;
        _smoothBar = smoothBar;

        _progressService.Changed += OnProgressChange;
        _smoothBar.Init(this);
    }

    private void OnProgressChange(int progress)
    {
        Changed?.Invoke(progress);
    }

    private void OnDestroy()
    {
        _progressService.Changed -= OnProgressChange;
    }
}