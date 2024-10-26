using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _prefabExplosionEffect;

    private int _destructionTimer = 2;

    public void ReproduceTankExplosion()
    {
        ParticleSystem explosionEffect = Instantiate(_prefabExplosionEffect, transform.position, Quaternion.identity);
        Destroy(explosionEffect.gameObject, _destructionTimer);
    }
}