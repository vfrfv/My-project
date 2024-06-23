using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHealth
{
    private int _health;
    private int _damage;

    private List<Enemy> _killedOpponents;

    private Enemy _target;

    public int Damage => _damage;
    public Enemy Target => _target;
    public int Value => _health;

    public event Action<int> Changed;

    private void Start()
    {
        _killedOpponents = new List<Enemy>();
        Changed?.Invoke(Value);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent(out EnemyMissile enemyMissile) ||
        //    other.TryGetComponent(out ArtaMissile artaMissile) ||
        //        other.TryGetComponent(out Barrels barrels))
        //{
        //    TakeDamage();
        //}
    }

    public void SetTarget(Enemy enemy)
    {
        _target = enemy;
    }

    public void LoseTarget()
    {
        _target = null;
    }

    public void Init(StatsDto statsDto)
    {
        _health = statsDto.Health;
        _damage = statsDto.Damage;
    }

    private void TakeDamage()
    {
        _health--;
        Changed?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        Debug.Log("Жизней" + _health + ", Дамага" + _damage);
    }
}
