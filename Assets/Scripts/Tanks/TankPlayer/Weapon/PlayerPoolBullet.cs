using Bullet;
using Bullet.PlayerBullet;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.TankPlayer.Weapon
{
    public class PlayerPoolBullet : BulletPoolBase<PlayerBullet>
    {
        public PlayerPoolBullet(PlayerBullet prefabMissile) : base(prefabMissile) { }
    }
}