using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoolBullet
{
    private PlayerBullet _prefabMissile;
    private Queue<PlayerBullet> _bulletQueue;

    public PlayerPoolBullet(PlayerBullet prefabMissile)
    {
        _prefabMissile = prefabMissile ?? throw new ArgumentNullException(nameof(prefabMissile));
        _bulletQueue = new Queue<PlayerBullet>();
    }

    public PlayerBullet GiveMissile(Vector3 position, Quaternion rotation)
    {
        if (_bulletQueue.Count < 1)
        {
            CreateMissile();
        }

        PlayerBullet bullet = _bulletQueue.Dequeue();

        bullet.gameObject.SetActive(true);
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;

        return bullet;
    }

    public void GetMissile(PlayerBullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletQueue.Enqueue(bullet);
    }

    public void CreateMissile()
    {
        PlayerBullet missile = GameObject.Instantiate(_prefabMissile);
        missile.gameObject.SetActive(false);
        _bulletQueue.Enqueue(missile);
    }
}
