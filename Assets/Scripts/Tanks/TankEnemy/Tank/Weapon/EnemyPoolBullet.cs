using Bullet.EnemyBullet;

namespace Tanks.TankEnemy.Tank.Weapon
{
    public class EnemyPoolBullet : BulletPoolBase<EnemyBullet>
    {
        public EnemyPoolBullet(EnemyBullet prefabMissile) : base(prefabMissile) { }
    }
}