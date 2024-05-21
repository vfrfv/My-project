using System;
using UnityEngine;

public class Player : MonoBehaviour , IHealth
{
    private Enemy _target;

    private int _health = 5;
    public Enemy Target => _target;

    public int Value => _health;

    public event Action<int> Changed;

    private void Start()
    {
        Changed?.Invoke(Value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyMissile enemyMissile) ||
            other.TryGetComponent(out ArtaMissile artaMissile) ||
                other.TryGetComponent(out Barrels barrels))
        {
            TakeDamage();
        }
    }

    public void SetTarget(Enemy enemy)
    {
        _target = enemy;
    }

    public void LoseTarget()
    {
        _target = null;
    }

    private void TakeDamage()
    {
        if (_health <= 0)
        {
            Die();
        }
        else
        {
            _health--;
            Changed?.Invoke(_health);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
