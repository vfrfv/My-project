using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private Barrier _barrier;

    private List<Enemy> _enemies = new List<Enemy>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (_enemies.Contains(enemy) == false)
            {
                _enemies.Add(enemy);
                enemy.Died += RemoveEnemy;

                UpdateBarrierState();
            }
        }
    }

    private void Update()
    {
        Debug.Log($"Количество врагов в зоне{_enemies.Count}");

        if (_enemies.Count <= 0)
        {
            //Debug.Log("Зона открыта");
            //_barrier.OpenZone();
        }
        else
        {
            //Debug.Log("Зона закрыта");
            //_barrier.CloseZone();
        }
    }

    private void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        enemy.Died -= RemoveEnemy;

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
