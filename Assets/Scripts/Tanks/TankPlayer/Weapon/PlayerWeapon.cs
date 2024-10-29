using Bullet;
using UnityEngine;

namespace Tanks.TankPlayer.Weapon
{
    public class PlayerWeapon : WeaponBase
    {
        [SerializeField] private Player _player;
        [SerializeField] private PlayerPoolHandler _poolHandler;

        public void InstallShootPoint(Transform shootPoint)
        {
            _shootPoint = shootPoint;
        }

        public new void Shoot()
        {
            base.Shoot();
        }

        protected override BulletBase CreateBullet()
        {
            BulletBase bullet = _poolHandler.Pool.GiveMissile(_shootPoint.position, _shootPoint.rotation);
            bullet.SetDamage(_player.Damage);

            return bullet;
        }

        protected override void ReturnMissile(BulletBase bullet)
        {
            bullet.Destroyed -= ReturnMissile;
            _poolHandler.Pool.ReleaseMissile(bullet);
        }
    }
}