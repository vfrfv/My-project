using System;
using UnityEngine;

public class Player : TankBase
{
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerWeapon _playerWeapon;
    [SerializeField] private MovementPlayerTank _movementPlayerTank;
    [SerializeField] private Transform _parentTransform;
    [SerializeField] private AudioSource _sfxPlayerPrefab;
    [SerializeField] private AudioClip _deathSound;

    private Enemy _target;
    private TankModel _model;

    public Enemy Target => _target;
    public event Action Died;

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyBullet enemyBullet))
        {
            TakeDamage(enemyBullet.Damage);
        }
    }

    public void SetTarget(Enemy target)
    {
        _target = target;
    }

    public void LoseTarget()
    {
        _target = null;
    }

    protected override void Die()
    {
        Destroy(gameObject);
        Died?.Invoke();

        AudioSource sfxInstance = Instantiate(_sfxPlayerPrefab, transform.position, Quaternion.identity);
        sfxInstance.PlayOneShot(_deathSound);

        Destroy(sfxInstance.gameObject, _deathSound.length);
    }

    public override void Init(UnitConfig unitConfig)
    {
        if (_model != null)
        {
            Destroy(_model.gameObject);
        }

        TankModel tankModel = Instantiate(unitConfig.TankModel, _parentTransform);

        _model = tankModel;
        _model.transform.position = _parentTransform.transform.position;
        _model.transform.rotation = _parentTransform.rotation;

        _playerAttack.InstallTower(_model.Tower);
        _playerWeapon.InstallShootPoint(_model.ShootPoint);
        _movementPlayerTank.InstallAnimator(_model.Animator);

        base.Init(unitConfig);
    }
}
