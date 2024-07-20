using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolHandler : MonoBehaviour
{
    [SerializeField] private EnemyBullet _prefabBullet;

    private EnemyPoolBullet _pool;

    public EnemyPoolBullet Pool => _pool;

    private void Awake()
    {
        _pool = new EnemyPoolBullet(_prefabBullet);
    }
}
