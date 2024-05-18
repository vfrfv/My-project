using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolHandler : MonoBehaviour
{
    [SerializeField] private EnemyMissile _prefabMissile;

    private EnemyPoolMissile _pool;

    public EnemyPoolMissile Pool => _pool;

    private void Awake()
    {
        _pool = new EnemyPoolMissile(_prefabMissile);
    }
}
