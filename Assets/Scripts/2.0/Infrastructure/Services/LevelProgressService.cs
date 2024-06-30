using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressService 
{
    // Следит за количеством фрагов и сообщает GameLoopService 

    private List<Enemy> _enemies = new List<Enemy>();
    private Barrier _barrier;
    private int _killedOpponents;

    public LevelProgressService(List<Enemy> enemies, Barrier barrier)
    {
        _enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
        _barrier = barrier ?? throw new ArgumentNullException(nameof(barrier));

        OnEnemiesDie();
    }
    
    public event Action Improved;
    public event Action MovedNextLevel;

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
            //_killedOpponents = 0;
        }

        if(_killedOpponents >= 4)
        {
           _barrier.OpenZone();
        }
    }
}
