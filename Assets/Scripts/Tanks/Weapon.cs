using System.Collections;
using Tanks.Controllers;
using UnityEngine;

namespace Tanks
{
    public sealed class Weapon : MonoBehaviour
    {
        [SerializeField] private Bullets.Bullet _bulletPrefab;
        [SerializeField] private TankBase _tank;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private TankEffects _effectsController;
        [SerializeField] private TankSound _soundController;
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

            Bullets.Bullet bullet = CreateBullet();
            _effectsController.PlayShootEffect(_shootPoint.transform);
            _soundController.PlayShootSound();
            bullet.Destroyed += ReturnMissile;

            StartCoroutine(StartCooldown());
        }

        private Bullets.Bullet CreateBullet()
        {
            Bullets.Bullet bullet = _bulletPool.GiveMissile(_shootPoint.position, _shootPoint.rotation);
            bullet.SetDamage(_tank.Damage);

            return bullet;
        }

        private void ReturnMissile(Bullets.Bullet bullet)
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