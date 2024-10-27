using Bullet;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletPoolBase<T> where T : BulletBase
{
    protected readonly T _prefabBullet;
    protected readonly Queue<BulletBase> _bulletQueue;

    protected BulletPoolBase(T prefabBullet)
    {
        _prefabBullet = prefabBullet ?? throw new ArgumentNullException(nameof(prefabBullet));
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

    public void ReleaseMissile(BulletBase bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletQueue.Enqueue(bullet);
    }

    protected virtual void CreateMissile()
    {
        T bullet = UnityEngine.Object.Instantiate(_prefabBullet);
        bullet.gameObject.SetActive(false);
        _bulletQueue.Enqueue(bullet);
    }
}