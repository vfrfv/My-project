using System;
using System.Collections.Generic;

public class FragmentCounter
{
    private List<Enemy> _enemies = new List<Enemy>();
    private int _killedOpponents;

    public FragmentCounter(List<Enemy> enemies)
    {
        _enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
    }

    public event Action Reached;

    public void GetEnemies()
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
            Reached?.Invoke();
        }
    }
}
