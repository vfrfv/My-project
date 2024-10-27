using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolHandler<TPool, TBullet> : MonoBehaviour where TPool : class
{
    [SerializeField] private TBullet _prefabBullet;

    protected TPool _pool;

    public TPool Pool => _pool;

    protected abstract TPool CreatePool(TBullet prefabBullet);

    private void Awake()
    {
        _pool = CreatePool(_prefabBullet);
    }
}
