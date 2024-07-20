using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , IValue
{
    [SerializeField] private UnitConfig _unitConfig;
    [SerializeField] private EnemyRadar _enemyRadar;
    [SerializeField] private EnemyWeapon _enemyWeapon;

    private Player _player;
    private int _health;
    private int _damage;
    private int _maxValue;

    public Player Player => _player;
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
        _enemyRadar.InstallFieldView(statsDto.FieldView);
        _enemyWeapon.InstallShootDelayInSeconds(statsDto.ShootDelayInSeconds);
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

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void LosePlayer()
    {
        _player = null;
    }
}
