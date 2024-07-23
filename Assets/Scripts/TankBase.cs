using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBase : MonoBehaviour
{
    protected int _maxHealth;
    protected int _health;
    protected int _damage;

    public int Damage => _damage;
    public int Value => _health;
    public int MaxValue => _maxHealth;

    public event Action<int> Changed;

    protected virtual void Start()
    {
        Changed?.Invoke(Value);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        // Implementation for specific units will be in derived classes
    }

    public void Init(StatsDto statsDto)
    {
        _maxHealth = statsDto.Health;
        _health = statsDto.Health;
        _damage = statsDto.Damage;
    }

    protected void TakeDamage(int damage)
    {
        _health -= damage;
        Changed?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    protected abstract void Die();
}
