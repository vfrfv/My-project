using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyPoolHandler))]
public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;

    private float _shootDelayCounter = 0;
    private float _shootDelayInSeconds = 4;
    private EnemyPoolHandler _poolHandler;

    public bool CanShoot => _shootDelayCounter <= 0;

    private void Awake()
    {
        _poolHandler = GetComponent<EnemyPoolHandler>();
    }

    public void InstallShootDelayInSeconds(float shootDelayInSeconds)
    {
        _shootDelayInSeconds = shootDelayInSeconds;
    }

    public void Shoot()
    {
        if (CanShoot == false)
        {
            return;
        }

        _shootDelayCounter = _shootDelayInSeconds;

        Bullet bullet = _poolHandler.Pool.GiveMissile(_shootPoint.transform.position, _shootPoint.transform.rotation);
        bullet.Destroyed += ReturnMissile;

        StartCoroutine(StartCooldown());
    }

    private void ReturnMissile(Bullet bullet)
    {
        _poolHandler.Pool.GetMissile(bullet);
        bullet.Destroyed -= ReturnMissile;
    }

    private IEnumerator StartCooldown()
    {
        while (CanShoot == false)
        {
            yield return null;
            _shootDelayCounter -= Time.deltaTime;
        }
    }
}
