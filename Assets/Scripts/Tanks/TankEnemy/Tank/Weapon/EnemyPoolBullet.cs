using Bullet;
using Bullet.EnemyBullet;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.TankEnemy.Tank.Weapon
{
    public class EnemyPoolBullet : BulletPoolBase<EnemyBullet>
    {
        public EnemyPoolBullet(EnemyBullet prefabMissile) : base(prefabMissile) { }
    }
}