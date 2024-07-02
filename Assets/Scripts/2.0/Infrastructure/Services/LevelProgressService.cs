using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressService  // Отвечает за прокаску уровня игрока, 
{
    private int _killedOpponents;
    private int _numberFragsUpgrade = 3;


    public event Action Improved;
    public event Action MovedNextLevel;

    public void AddProgress(Enemy enemy)
    {
        _killedOpponents++;

        if (_killedOpponents >= _numberFragsUpgrade)
        {
            Improved?.Invoke();
            _killedOpponents = 0;
        }
    }
}
