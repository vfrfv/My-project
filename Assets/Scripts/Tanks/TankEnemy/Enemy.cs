using Bullet.PlayerBullet;
using ScriptableObjects;
using System;
using Tanks.Controllers;
using UnityEngine;

namespace Tanks.TankEnemy
{
    public class Enemy : TankBase
    {
        [SerializeField] private UnitConfig _unitConfig;
        [SerializeField] private EffectsController _effectsController;
        [SerializeField] private SoundController _soundController;

        private float _shootDelayInSeconds;

        public float ShootDelayInSeconds => _shootDelayInSeconds;

        public event Action<Enemy> Died;

        private void Awake()
        {
            Init(_unitConfig);
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerBullet bullet))
            {
                TakeDamage(bullet.Damage);
            }
        }

        protected override void Die()
        {
            Died?.Invoke(this);

            _soundController.PlaySoundEnemyDeath();
            _effectsController.ReproduceTankExplosion();

            Destroy(gameObject, 0.05f);
        }

        private new void Init(UnitConfig statsDto)
        {
            base.Init(statsDto);
            _shootDelayInSeconds = statsDto.ShootDelayInSeconds;
        }
    }
}