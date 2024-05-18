using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerPoolMissile
{
    private Missile _prefabMissile;
    private Queue<Missile> _missileQueue;

    public PlayerPoolMissile(Missile prefabMissile)
    {
        _prefabMissile = prefabMissile ?? throw new ArgumentNullException(nameof(prefabMissile));
        _missileQueue = new Queue<Missile>();
    }

    public Missile GiveMissile(Vector3 position, Quaternion rotation)
    {
        if(_missileQueue.Count < 1)
        {
            CreateMissile();
        }

        Missile missile = _missileQueue.Dequeue();

        missile.gameObject.SetActive(true);
        missile.transform.position = position;
        missile.transform.rotation = rotation;

        return missile;
    }

    public void GetMissile(Missile missile)
    {
        missile.gameObject.SetActive(false);
        _missileQueue.Enqueue(missile);
    }

    private void CreateMissile()
    {
        Missile missile = GameObject.Instantiate(_prefabMissile);
        missile.gameObject.SetActive(false);
        _missileQueue.Enqueue(missile);
    }
}
