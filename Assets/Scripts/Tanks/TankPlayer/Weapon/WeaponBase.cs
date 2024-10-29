using Bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected Transform _shootPoint;
    [SerializeField] protected ParticleSystem _prefabShoot;
    [SerializeField] protected AudioSource _shootSound;
    [SerializeField] protected float _shootDelayInSeconds = 1;

    protected float _shootDelayCounter = 0;

    public bool CanShoot => _shootDelayCounter <= 0;

    protected virtual void Shoot()
    {
        if (!CanShoot) return;

        _shootDelayCounter = _shootDelayInSeconds;

        BulletBase bullet = CreateBullet();
        PlayShootEffect();
        PlayShootSound();
        bullet.Destroyed += ReturnMissile;

        StartCoroutine(StartCooldown());
    }

    protected abstract BulletBase CreateBullet();

    protected virtual void PlayShootEffect()
    {
        var shootEffect = Instantiate(_prefabShoot, _shootPoint.position, _shootPoint.rotation);
        Destroy(shootEffect.gameObject, 1);
    }

    protected virtual void PlayShootSound()
    {
        _shootSound.Play();
    }

    protected abstract void ReturnMissile(BulletBase bullet);

    private IEnumerator StartCooldown()
    {
        while (!CanShoot)
        {
            yield return null;
            _shootDelayCounter -= Time.fixedDeltaTime;
        }
    }
}