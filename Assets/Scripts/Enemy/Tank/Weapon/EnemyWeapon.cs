using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPoolHandler))]
public class EnemyWeapon : MonoBehaviour
{
    private float _shootDelayCounter = 0;
    private readonly float _shootDelayInSeconds = 1;
    private EnemyPoolHandler _poolHandler;

    public bool CanShoot => _shootDelayCounter <= 0;

    private void Awake()
    {
        _poolHandler = GetComponent<EnemyPoolHandler>();
    }

    public void Shoot()
    {
        if (CanShoot == false)
        {
            return;
        }

        _shootDelayCounter = _shootDelayInSeconds;

        EnemyMissile missile = _poolHandler.Pool.GiveMissile(transform.position, transform.rotation);
        missile.Destroyed += ReturnMissile;

        StartCoroutine(StartCooldown());
    }

    private void ReturnMissile(EnemyMissile missile)
    {
        _poolHandler.Pool.GetMissile(missile);
    }

    private IEnumerator StartCooldown()
    {
        float step = 0.01f;
        var wait = new WaitForSeconds(step);

        while (CanShoot == false)
        {
            _shootDelayCounter -= step;

            yield return wait;
        }
    }
}
