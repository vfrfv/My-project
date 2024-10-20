using Bullet;
using Bullet.PlayerBullet;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.TankPlayer.Weapon
{
    public class PlayerPoolBullet
    {
        private readonly PlayerBullet _prefabMissile;
        private readonly Queue<BulletBase> _bulletQueue;

        public PlayerPoolBullet(PlayerBullet prefabMissile)
        {
            _prefabMissile = prefabMissile ?? throw new ArgumentNullException(nameof(prefabMissile));
            _bulletQueue = new Queue<BulletBase>();
        }

        public BulletBase GiveMissile(Vector3 position, Quaternion rotation)
        {
            if (_bulletQueue.Count < 1)
            {
                CreateMissile();
            }

            BulletBase bullet = _bulletQueue.Dequeue();

            bullet.gameObject.SetActive(true);
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;

            return bullet;
        }

        public void GetMissile(BulletBase bullet)
        {
            bullet.gameObject.SetActive(false);
            _bulletQueue.Enqueue(bullet);
        }

        private void CreateMissile()
        {
            PlayerBullet bullet = UnityEngine.Object.Instantiate(_prefabMissile);
            bullet.gameObject.SetActive(false);
            _bulletQueue.Enqueue(bullet);
        }
    }
}