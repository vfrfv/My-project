using UnityEngine;

public class Player : TankBase /*MonoBehaviour, IValue*/
{
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerWeapon _playerWeapon;
    [SerializeField] private Transform _parentTransform;

    private Enemy _target;
    private TankModel _model;

    public Enemy Target => _target;

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
    }

    public override void Init(UnitConfig unitConfig)
    {
        if(_model != null)
        {
            Destroy(_model.gameObject);
        }

        TankModel tankModel = Instantiate(unitConfig.TankModel, _parentTransform);

        _model = tankModel;
        _model.transform.position = _parentTransform.transform.position;
        _model.transform.rotation = _parentTransform.rotation;

        _playerAttack.InstallTower(_model.Tower);
        _playerWeapon.InstallShootPoint(_model.ShootPoint);

        base.Init(unitConfig);
    }

    //private int _maxHealth;
    //private int _health;
    //private int _damage;
    //private Enemy _target;

    //public int Damage => _damage;
    //public Enemy Target => _target;
    //public int Value => _health;
    //public int MaxValue => _maxHealth;

    //public event Action<int> Changed;

    //private void Start()
    //{
    //    Changed?.Invoke(Value);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent(out EnemyBullet enemyBullet))
    //    {
    //        TakeDamage(enemyBullet.Damage);
    //    }
    //}

    //public void SetTarget(Enemy target)
    //{
    //    _target = target;
    //}

    //public void LoseTarget()
    //{
    //    _target = null;
    //}

    //public void Init(StatsDto statsDto)
    //{
    //    _maxHealth = statsDto.Health;
    //    _health = statsDto.Health;
    //    _damage = statsDto.Damage;
    //}

    //private void TakeDamage(int damage)
    //{
    //    _health -= damage;
    //    Changed?.Invoke(_health);

    //    if (_health <= 0)
    //    {
    //        Die();
    //    }
    //}

    //private void Die()
    //{
    //    Destroy(gameObject);
    //}
}
