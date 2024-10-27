using Bullet.PlayerBullet;
using UnityEngine;

namespace Tanks.TankPlayer.Weapon
{
    public class PlayerPoolHandler : PoolHandler<PlayerPoolBullet, PlayerBullet>
    {
        protected override PlayerPoolBullet CreatePool(PlayerBullet prefabBullet)
        {
            return new PlayerPoolBullet(prefabBullet);
        }
    }
}