using Bullets;
using ScriptableObjects;
using System;
using Tanks.Controllers;
using UnityEngine;

namespace Tanks.TankPlayer
{
    public class Player : TankBase
    {
        [SerializeField] private Attack _playerAttack;
        [SerializeField] private Weapon _playerWeapon;
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private AnimationController animationController;

        private TankModel _model;

        public event Action Died;

        //protected override void OnTriggerEnter(Collider other)
        //{
        //    if (other.TryGetComponent(out Bullet enemyBullet))
        //    {
        //        TakeDamage(enemyBullet.Damage);
        //    }
        //}


        public override void Init(UnitConfig unitConfig)
        {
            if (_model != null)
            {
                Destroy(_model.gameObject);
            }

            TankModel tankModel = Instantiate(unitConfig.TankModel, _parentTransform);

            _model = tankModel;
            _model.transform.position = _parentTransform.transform.position;
            _model.transform.rotation = _parentTransform.rotation;

            _playerAttack.InstallTower(_model.Tower);
            _playerWeapon.InstallShootPoint(_model.ShootPoint);
            animationController.InstallAnimator(_model.Animator);

            base.Init(unitConfig);
        }

        protected override void Die()
        {
            Destroy(gameObject);
            Died?.Invoke();

            _soundController.PlaySoundPlayerDeath();
        }
    }
}