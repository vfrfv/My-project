using Bar;
using Bullets;
using ScriptableObjects;
using System;
using Tanks.Controllers;
using UnityEngine;

namespace Tanks
{
    public abstract class TankBase : Health, IValue
    {
        [SerializeField] private TankType _typeTank;
        [SerializeField] private BulletType _bulletType;
        [SerializeField] protected SoundController _soundController;

        private int _maxHealth;
        private int _health;
        private int _damage;
        private TankBase _target;
        private TankModel _tankModel;

        public int Damage => _damage;
        public int Value => _health;
        public int MaxValue => _maxHealth;
        public TankBase Target => _target;

        public TankType Type => _typeTank;

        public event Action<int> Changed;

        private void Start()
        {
            Changed?.Invoke(Value);
        }

        //protected virtual void OnTriggerEnter(Collider other) { }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Bullet bullet))
            {
                if (bullet.Type == _bulletType)
                {
                    TakeDamage(bullet.Damage);
                }
            }
        }

        public virtual void Init(UnitConfig unitConfig)
        {
            _maxHealth = unitConfig.Health;
            _health = unitConfig.Health;
            _damage = unitConfig.Damage;

            Changed?.Invoke(_health);
        }

        public void SetTarget(TankBase target) => _target = target;

        public void LoseTarget() => _target = null;

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