using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private readonly Bullet.Bullet _prefabBullet;
    private readonly Queue<Bullet.Bullet> _bulletQueue;

    public BulletPool(Bullet.Bullet prefabBullet)
    {
        _prefabBullet = prefabBullet ?? throw new ArgumentNullException(nameof(prefabBullet));
        _bulletQueue = new Queue<Bullet.Bullet>();
    }

    public Bullet.Bullet GiveMissile(Vector3 position, Quaternion rotation)
    {
        if (_bulletQueue.Count < 1)
        {
            CreateMissile();
        }

        Bullet.Bullet bullet = _bulletQueue.Dequeue();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;

        return bullet;
    }

    public void ReleaseMissile(Bullet.Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletQueue.Enqueue(bullet);
    }

    private void CreateMissile()
    {
        Bullet.Bullet bullet = UnityEngine.Object.Instantiate(_prefabBullet);
        bullet.gameObject.SetActive(false);
        _bulletQueue.Enqueue(bullet);
    }
}
