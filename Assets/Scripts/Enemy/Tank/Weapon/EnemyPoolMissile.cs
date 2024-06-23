using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolMissile : MonoBehaviour
{
    private EnemyBullet _prefabMissile;
    private Queue<EnemyBullet> _missileQueue;

    public EnemyPoolMissile(EnemyBullet prefabMissile)
    {
        _prefabMissile = prefabMissile ?? throw new ArgumentNullException(nameof(prefabMissile));
        _missileQueue = new Queue<EnemyBullet>();
    }

    public EnemyBullet GiveMissile(Vector3 position, Quaternion rotation)
    {
        if (_missileQueue.Count < 1)
        {
            CreateMissile();
        }

        EnemyBullet missile = _missileQueue.Dequeue();

        missile.gameObject.SetActive(true);
        missile.transform.position = position;
        missile.transform.rotation = rotation;

        return missile;
    }

    public void GetMissile(EnemyBullet missile)
    {
        missile.gameObject.SetActive(false);
        _missileQueue.Enqueue(missile);
    }

    private void CreateMissile()
    {
        EnemyBullet missile = GameObject.Instantiate(_prefabMissile);
        missile.gameObject.SetActive(false);
        _missileQueue.Enqueue(missile);
    }
}
