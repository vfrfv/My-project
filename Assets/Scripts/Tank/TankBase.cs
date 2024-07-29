using System;
using UnityEngine;

public abstract class TankBase : MonoBehaviour, IValue
{
    protected int _maxHealth;
    protected int _health;
    protected int _damage;
    protected TankModel _tankModel;

    public int Damage => _damage;
    public int Value => _health;
    public int MaxValue => _maxHealth;

    public event Action<int> Changed;

    protected virtual void Start()
    {
        Changed?.Invoke(Value);
    }

    protected virtual void OnTriggerEnter(Collider other) { }

    public virtual void Init(UnitConfig unitConfig)
    {
        _maxHealth = unitConfig.Health;
        _health = unitConfig.Health;
        _damage = unitConfig.Damage;
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
