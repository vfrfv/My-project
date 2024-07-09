using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressService 
{
    private int _killedOpponents;
    private int _numberFragsUpgrade = 3;

    public int Value => _killedOpponents;

    public event Action Improved;
    public event Action MovedNextLevel;
    public event Action<int> Changed;

    public void AddProgress(Enemy enemy)
    {
        _killedOpponents++;
        Changed?.Invoke(_killedOpponents);

        if (_killedOpponents >= _numberFragsUpgrade)
        {
            Improved?.Invoke();
            _killedOpponents = 0;
            Changed?.Invoke(_killedOpponents);
        }
    }
}
