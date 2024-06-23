using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressService 
{
    // Следит за количеством фрагов и сообщает GameLoopService 

    private List<Enemy> _enemies = new List<Enemy>();
    private int _killedOpponents;

    public LevelProgressService(List<Enemy> enemies)
    {
        _enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
        OnEnemiesDie();
    }

    public event Action Improved;

    public void OnEnemiesDie()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Died += AddDeadEnemy;
        }
    }

    private void AddDeadEnemy(Enemy enemy)
    {
        _killedOpponents++;
        enemy.Died -= AddDeadEnemy;

        if (_killedOpponents >= 2)
        {
            Improved?.Invoke();
            _killedOpponents = 0;
        }
    }
}
