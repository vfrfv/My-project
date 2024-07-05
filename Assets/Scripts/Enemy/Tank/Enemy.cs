using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , IHealth
{
    [SerializeField] private UnitConfig _unitConfig;

    private Player _player;
    private int _health;
    private int _damage;

    public Player Player => _player;
    public int Damage => _damage;
    public int Value => _health;

    public event Action<Enemy> Died;
    public event Action<int> Changed;

    private void Start()
    {
        Init(_unitConfig.GetStats());
        Changed?.Invoke(_health);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            TakeDamage(bullet.Damage);        
        }
    }

    public void Init(StatsDto statsDto)
    {
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
        Destroy(gameObject);
        Died?.Invoke(this);
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void LosePlayer()
    {
        _player = null;
    }
}
