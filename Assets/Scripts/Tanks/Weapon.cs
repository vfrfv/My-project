using Bullet;
using System.Collections;
using UnityEngine;

namespace Tanks.TankPlayer
{
    public sealed class Weapon : MonoBehaviour
    {
        [SerializeField] private Bullet.Bullet _bulletPrefab;
        [SerializeField] private TankBase _tank;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private EffectsController _effectsController;
        [SerializeField] private SoundController _soundController;
        [SerializeField] private float _shootDelayInSeconds = 1;

        private float _shootDelayCounter = 0;
        private BulletPool _bulletPool;

        private bool CanShoot => _shootDelayCounter <= 0;

        private void Awake()
        {
            _bulletPool = new BulletPool(_bulletPrefab);
        }

        public void InstallShootPoint(Transform shootPoint)
        {
            _shootPoint = shootPoint;
        }

        public void Shoot()
        {
            if (!CanShoot) return;

            _shootDelayCounter = _shootDelayInSeconds;

            Bullet.Bullet bullet = CreateBullet();
            _effectsController.PlayShootEffect(_shootPoint.transform);
            _soundController.PlayShootSound();
            bullet.Destroyed += ReturnMissile;

            StartCoroutine(StartCooldown());
        }

        private Bullet.Bullet CreateBullet()
        {
            Bullet.Bullet bullet = _bulletPool.GiveMissile(_shootPoint.position, _shootPoint.rotation);
            bullet.SetDamage(_tank.Damage);

            return bullet;
        }

        private void ReturnMissile(Bullet.Bullet bullet)
        {
            bullet.Destroyed -= ReturnMissile;
            _bulletPool.ReleaseMissile(bullet);
        }

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