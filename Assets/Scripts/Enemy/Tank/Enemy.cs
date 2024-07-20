using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , IValue
{
    [SerializeField] private UnitConfig _unitConfig;

    private Player _target;
    private int _health;
    private int _damage;
    private int _maxValue;

    public Player Player => _target;
    public int Damage => _damage;
    public int Value => _health;
    public int MaxValue => _maxValue;

    public event Action<Enemy> Died;
    public event Action<int> Changed;

    private void Start()
    {
        Init(_unitConfig.GetStats());
        Changed?.Invoke(_health);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBullet>(out PlayerBullet bullet))
        {
            TakeDamage(bullet.Damage);        
        }
    }

    public void Init(StatsDto statsDto)
    {
        _maxValue = statsDto.Health;
        _health = statsDto.Health;
        _damage = statsDto.Damage;
    }

    private void TakeDamage(int damage)
    {
        _health-= damage;
        Changed?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }

    public void SetTarget(Player target)
    {
        _target = target;
    }

    public void LosePlayer()
    {
        _target = null;
    }
}
