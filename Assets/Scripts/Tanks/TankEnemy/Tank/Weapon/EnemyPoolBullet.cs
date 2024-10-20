using Bullet;
using Bullet.EnemyBullet;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.TankEnemy.Tank.Weapon
{
    public class EnemyPoolBullet : MonoBehaviour
    {
        private readonly EnemyBullet _prefabBullet;
        private readonly Queue<BulletBase> _missileQueue;

        public EnemyPoolBullet(EnemyBullet prefabMissile)
        {
            _prefabBullet = prefabMissile ?? throw new ArgumentNullException(nameof(prefabMissile));
            _missileQueue = new Queue<BulletBase>();
        }

        public BulletBase GiveMissile(Vector3 position, Quaternion rotation)
        {
            if (_missileQueue.Count < 1)
            {
                CreateMissile();
            }

            BulletBase missile = _missileQueue.Dequeue();

            missile.gameObject.SetActive(true);
            missile.transform.position = position;
            missile.transform.rotation = rotation;

            return missile;
        }

        public void GetMissile(BulletBase bullet)
        {
            bullet.gameObject.SetActive(false);
            _missileQueue.Enqueue(bullet);
        }

        private void CreateMissile()
        {
            EnemyBullet bullet = Instantiate(_prefabBullet);
            bullet.gameObject.SetActive(false);
            _missileQueue.Enqueue(bullet);
        }
    }
}