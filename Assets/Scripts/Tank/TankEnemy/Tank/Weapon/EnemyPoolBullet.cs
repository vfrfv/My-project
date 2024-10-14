using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolBullet : MonoBehaviour
{
    private readonly EnemyBullet _prefabBullet;
    private readonly Queue<Bullet> _missileQueue;

    public EnemyPoolBullet(EnemyBullet prefabMissile)
    {
        _prefabBullet = prefabMissile ?? throw new ArgumentNullException(nameof(prefabMissile));
        _missileQueue = new Queue<Bullet>();
    }

    public Bullet GiveMissile(Vector3 position, Quaternion rotation)
    {
        if (_missileQueue.Count < 1)
        {
            CreateMissile();
        }

        Bullet missile = _missileQueue.Dequeue();

        missile.gameObject.SetActive(true);
        missile.transform.position = position;
        missile.transform.rotation = rotation;

        return missile;
    }

    public void GetMissile(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _missileQueue.Enqueue(bullet);
    }

    private void CreateMissile()
    {
        EnemyBullet bullet = GameObject.Instantiate(_prefabBullet);
        bullet.gameObject.SetActive(false);
        _missileQueue.Enqueue(bullet);
    }
}