using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private Barrier _barrier;

    private List<Enemy> _enemies = new List<Enemy>();
    private GameLoopService _loopService;

    public List<Enemy> Enemies => _enemies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (_enemies.Contains(enemy) == false)
            {
                _enemies.Add(enemy);
                enemy.Died += RemoveEnemy;
                _loopService.OnEnemiesDie(enemy);

                UpdateBarrierState();
            }
        }
    }

    //private void Update()
    //{
    //    Debug.Log($"Количество врагов в зоне{_enemies.Count}");
    //}

    public void Init(GameLoopService gameLoopService)
    {
        _loopService = gameLoopService;
    }

    private void RemoveEnemy(Enemy enemy)
    {
        enemy.Died -= RemoveEnemy;
        _enemies.Remove(enemy);

        UpdateBarrierState();
    }

    private void UpdateBarrierState()
    {
        if (_enemies.Count <= 0)
            _barrier.OpenZone();
        else
            _barrier.CloseZone();
    }
}
