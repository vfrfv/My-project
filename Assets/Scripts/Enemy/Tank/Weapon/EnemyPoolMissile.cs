using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolMissile : MonoBehaviour
{
    private EnemyMissile _prefabMissile;
    private Queue<EnemyMissile> _missileQueue;

    public EnemyPoolMissile(EnemyMissile prefabMissile)
    {
        _prefabMissile = prefabMissile ?? throw new ArgumentNullException(nameof(prefabMissile));
        _missileQueue = new Queue<EnemyMissile>();
    }

    public EnemyMissile GiveMissile(Vector3 position, Quaternion rotation)
    {
        if (_missileQueue.Count < 1)
        {
            CreateMissile();
        }

        EnemyMissile missile = _missileQueue.Dequeue();

        missile.gameObject.SetActive(true);
        missile.transform.position = position;
        missile.transform.rotation = rotation;

        return missile;
    }

    public void GetMissile(EnemyMissile missile)
    {
        missile.gameObject.SetActive(false);
        _missileQueue.Enqueue(missile);
    }

    private void CreateMissile()
    {
        EnemyMissile missile = GameObject.Instantiate(_prefabMissile);
        missile.gameObject.SetActive(false);
        _missileQueue.Enqueue(missile);
    }
}
