using System;
using UnityEngine;

public class Enemy : TankBase
{
    [SerializeField] private UnitConfig _unitConfig;
    [SerializeField] private ParticleSystem _prefabExplosionEffect;
    [SerializeField] private AudioSource _sfxPlayerPrefab;
    [SerializeField] private AudioClip _deathSound;

    private Player _target;
    private float _shootDelayInSeconds;

    public Player Player => _target;
    public float ShootDelayInSeconds => _shootDelayInSeconds;

    public event Action<Enemy> Died;

    private void Awake()
    {
        Init(_unitConfig);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBullet>(out PlayerBullet bullet))
        {
            TakeDamage(bullet.Damage);
        }
    }

    public new void Init(UnitConfig statsDto)
    {
        base.Init(statsDto);
        _shootDelayInSeconds = statsDto.ShootDelayInSeconds;
    }

    protected override void Die()
    {
        Died?.Invoke(this);

        ParticleSystem explosionEffect = Instantiate(_prefabExplosionEffect, transform.position, Quaternion.identity);
        AudioSource sfxInstance = Instantiate(_sfxPlayerPrefab, transform.position, Quaternion.identity);
        sfxInstance.PlayOneShot(_deathSound);

        Destroy(sfxInstance.gameObject, _deathSound.length);
        Destroy(explosionEffect.gameObject, 2);
        Destroy(gameObject, 0.01f);
    }

    public void SetTarget(Player target)
    {
        _target = target;
    }

    public void LosePlayer()
    {
        _target = null;
    }
}
