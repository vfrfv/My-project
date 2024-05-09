using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Missile>(out Missile missile))
        {
            Destroy(gameObject);
            Died?.Invoke(this);
        }
    }
}
