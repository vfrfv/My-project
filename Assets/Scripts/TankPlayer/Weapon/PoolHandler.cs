using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolHandler : MonoBehaviour
{
    [SerializeField] private Missile _prefabMissile;

    private PoolMissile _pool;

    public PoolMissile Pool => _pool;

    private void Awake()
    {
        _pool = new PoolMissile(_prefabMissile);
    }
}
