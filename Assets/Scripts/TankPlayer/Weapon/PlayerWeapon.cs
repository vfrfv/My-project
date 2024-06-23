using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerPoolHandler))]
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private readonly float _shootDelayInSeconds = 1;
    [SerializeField] private Player _player;

    private float _shootDelayCounter = 0;
    private PlayerPoolHandler _poolHandler;

    public bool CanShoot => _shootDelayCounter <= 0;
    //public bool CanShoot = true;

    private void Awake()
    {
        _poolHandler = GetComponent<PlayerPoolHandler>();
    }

    public void Shoot()
    {
        if (CanShoot == false)
        {
            return;
        }

        _shootDelayCounter = _shootDelayInSeconds;

        Bullet bullet = _poolHandler.Pool.GiveMissile(transform.position, transform.rotation);
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
            _shootDelayCounter -= Time.deltaTime;
        }
    }
}
