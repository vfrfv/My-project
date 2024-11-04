using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private readonly Bullets.Bullet _prefabBullet;
    private readonly Queue<Bullets.Bullet> _bulletQueue;

    public BulletPool(Bullets.Bullet prefabBullet)
    {
        _prefabBullet = prefabBullet ?? throw new ArgumentNullException(nameof(prefabBullet));
        _bulletQueue = new Queue<Bullets.Bullet>();
    }

    public Bullets.Bullet GiveMissile(Vector3 position, Quaternion rotation)
    {
        if (_bulletQueue.Count < 1)
        {
            CreateMissile();
        }

        Bullets.Bullet bullet = _bulletQueue.Dequeue();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;

        return bullet;
    }

    public void ReleaseMissile(Bullets.Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletQueue.Enqueue(bullet);
    }

    private void CreateMissile()
    {
        Bullets.Bullet bullet = UnityEngine.Object.Instantiate(_prefabBullet);
        bullet.gameObject.SetActive(false);
        _bulletQueue.Enqueue(bullet);
    }
}
