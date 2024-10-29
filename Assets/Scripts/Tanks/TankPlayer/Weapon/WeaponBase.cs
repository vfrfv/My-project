using Bullet;
using System.Collections;
using UnityEngine;

namespace Tanks.TankPlayer.Weapon
{
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField] protected Transform _shootPoint;
        //[SerializeField] protected ParticleSystem _prefabShoot;
        //[SerializeField] protected AudioSource _shootSound;
        [SerializeField] protected EffectsController _effectsController;
        [SerializeField] protected SoundController _soundController;
        [SerializeField] protected float _shootDelayInSeconds = 1;

        protected float _shootDelayCounter = 0;

        public bool CanShoot => _shootDelayCounter <= 0;

        protected virtual void Shoot()
        {
            if (!CanShoot) return;

            _shootDelayCounter = _shootDelayInSeconds;

            BulletBase bullet = CreateBullet();
            _effectsController.PlayShootEffect(_shootPoint.transform);
            _soundController.PlayShootSound();
            bullet.Destroyed += ReturnMissile;

            StartCoroutine(StartCooldown());
        }

        protected abstract BulletBase CreateBullet();

        protected abstract void ReturnMissile(BulletBase bullet);

        private IEnumerator StartCooldown()
        {
            while (!CanShoot)
            {
                yield return null;
                _shootDelayCounter -= Time.fixedDeltaTime;
            }
        }
    }
}