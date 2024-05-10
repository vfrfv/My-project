using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PoolHandler))]
public class Weapon : MonoBehaviour
{
    private float _shootDelayCounter = 0;
    private readonly float _shootDelayInSeconds = 1;
    private PoolHandler _poolHandler;

    public bool CanShoot => _shootDelayCounter <= 0;

    private void Awake()
    {
        _poolHandler = GetComponent<PoolHandler>();
    }

    public void Shoot()
    {
        if (CanShoot == false)
        {
            return;
        }

        _shootDelayCounter = _shootDelayInSeconds;

        Missile missile = _poolHandler.Pool.GiveMissile(transform.position, transform.rotation);
        missile.Destroyed += ReturnMissile;

        StartCoroutine(StartCooldown());
    }

    private void ReturnMissile(Missile missile)
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
