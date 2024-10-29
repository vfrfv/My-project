using Bullet.PlayerBullet;
using ScriptableObjects;
using System;
using Tanks.TankPlayer;
using UnityEngine;

namespace Tanks.TankEnemy.Tank
{
    public class Enemy : TankBase
    {
        [SerializeField] private UnitConfig _unitConfig;
        [SerializeField] private EffectsController _effectsController;
        [SerializeField] private SoundController _soundController;

        private Player _target;
        private float _shootDelayInSeconds;

        public Player Player => _target;
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

        public void SetTarget(Player target)
        {
            _target = target;
        }

        public void LosePlayer()
        {
            _target = null;
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