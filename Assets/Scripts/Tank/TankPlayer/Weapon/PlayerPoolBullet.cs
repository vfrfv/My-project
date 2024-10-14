using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoolBullet
{
    private PlayerBullet _prefabMissile;
    private Queue<Bullet> _bulletQueue;

    public PlayerPoolBullet(PlayerBullet prefabMissile)
    {
        _prefabMissile = prefabMissile ?? throw new ArgumentNullException(nameof(prefabMissile));
        _bulletQueue = new Queue<Bullet>();
    }

    public Bullet GiveMissile(Vector3 position, Quaternion rotation)
    {
        if (_bulletQueue.Count < 1)
        {
            CreateMissile();
        }

        Bullet bullet = _bulletQueue.Dequeue();

        bullet.gameObject.SetActive(true);
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;

        return bullet;
    }

    public void GetMissile(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletQueue.Enqueue(bullet);
    }

    public void CreateMissile()
    {
        PlayerBullet bullet = GameObject.Instantiate(_prefabMissile);
        bullet.gameObject.SetActive(false);
        _bulletQueue.Enqueue(bullet);
    }
}