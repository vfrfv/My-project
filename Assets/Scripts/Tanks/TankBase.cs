using Assets.Scripts.Bar;
using Assets.Scripts.ScriptableObjects;
using System;
using UnityEngine;

namespace Assets.Scripts.Tanks
{
    public abstract class TankBase : MonoBehaviour, IValue
    {
        private int _maxHealth;
        private int _health;
        private int _damage;
        private TankModel _tankModel;

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

            Changed?.Invoke(_health);
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
}