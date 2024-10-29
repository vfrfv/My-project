using Bullet;
using Tanks.TankPlayer.Weapon;
using UnityEngine;

namespace Tanks.TankEnemy.Tank.Weapon
{
    public class EnemyWeapon : WeaponBase
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private EnemyPoolHandler _poolHandler;

        private void Start()
        {
            _shootDelayInSeconds = _enemy.ShootDelayInSeconds;
        }

        public new void Shoot()
        {
            base.Shoot();
        }

        protected override BulletBase CreateBullet()
        {
            BulletBase bullet = _poolHandler.Pool.GiveMissile(_shootPoint.position, _shootPoint.rotation);
            bullet.SetDamage(_enemy.Damage);

            return bullet;
        }

        protected override void ReturnMissile(BulletBase bullet)
        {
            bullet.Destroyed -= ReturnMissile;
            _poolHandler.Pool.ReleaseMissile(bullet);
        }
    }
}