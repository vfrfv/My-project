using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerPoolHandler))]
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _prefabShot;

    private Transform _shootPoint;
    private float _shootDelayCounter = 0;
    private float _shootDelayInSeconds = 1;
    private PlayerPoolHandler _poolHandler;

    public bool CanShoot => _shootDelayCounter <= 0;

    private void Awake()
    {
        _poolHandler = GetComponent<PlayerPoolHandler>();
    }

    public void InstallShootPoint(Transform shootPoint)
    {
        _shootPoint = shootPoint;
    }

    public void Shoot()
    {
        if (CanShoot == false)
        {
            return;
        }

        _shootDelayCounter = _shootDelayInSeconds;

        Bullet bullet = _poolHandler.Pool.GiveMissile(_shootPoint.transform.position, _shootPoint.transform.rotation);
        Instantiate(_prefabShot, _shootPoint.transform.position, _shootPoint.transform.rotation);
        bullet.SetDamage(_player.Damage);
        bullet.Destroyed += ReturnMissile;

        StartCoroutine(StartCooldown());
    }

    private void ReturnMissile(Bullet bullet)
    {
        bullet.Destroyed -= ReturnMissile;
        _poolHandler.Pool.GetMissile(bullet);
    }

    private IEnumerator StartCooldown()
    {
        while (CanShoot == false)
        {
            yield return null;
            _shootDelayCounter -= Time.fixedDeltaTime;
        }
    }
}
