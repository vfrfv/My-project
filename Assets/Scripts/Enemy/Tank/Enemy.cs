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
    private float _shootDelayInSeconds;

    public Player Player => _target;
    public int Damage => _damage;
    public int Value => _health;
    public int MaxValue => _maxValue;
    public float ShootDelayInSeconds => _shootDelayInSeconds;

    public event Action<Enemy> Died;
    public event Action<int> Changed;

    private void Awake()
    {
        Init(_unitConfig.GetStats());     
    }

    private void Start()
    {
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
        _shootDelayInSeconds = statsDto.ShootDelayInSeconds;
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
        Destroy(gameObject, 0.01f);
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
