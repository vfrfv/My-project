using Bullet.EnemyBullet;

namespace Tanks.TankEnemy.Tank.Weapon
{
    public class EnemyPoolHandler : PoolHandler<EnemyPoolBullet, EnemyBullet>
    {
        protected override EnemyPoolBullet CreatePool(EnemyBullet prefabBullet)
        {
            return new EnemyPoolBullet(prefabBullet);
        }
    }
}