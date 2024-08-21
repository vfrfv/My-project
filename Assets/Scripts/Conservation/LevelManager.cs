using System;
using UnityEngine;

[Serializable]
public class LevelManager
{
    [SerializeField] private int _currentLevel = 1;

    public int CurrentLevel => _currentLevel;

    public void CompleteLevel()
    {
        _currentLevel++;
    }
}
