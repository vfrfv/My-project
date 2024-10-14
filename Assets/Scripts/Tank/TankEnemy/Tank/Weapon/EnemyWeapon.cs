using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyPoolHandler))]
public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ParticleSystem _prefabShoot;
    [SerializeField] private AudioSource _shootSound;

    private float _shootDelayCounter = 0;
    private float _shootDelayInSeconds;
    private EnemyPoolHandler _poolHandler;

    public bool CanShoot => _shootDelayCounter <= 0;

    private void Awake()
    {
        _poolHandler = GetComponent<EnemyPoolHandler>();
    }

    private void Start()
    {
        _shootDelayInSeconds = _enemy.ShootDelayInSeconds;      
    }

    public void Shoot()
    {
        if (CanShoot == false)
        {
            return;
        }

        _shootDelayCounter = _shootDelayInSeconds;

        Bullet bullet = _poolHandler.Pool.GiveMissile(_shootPoint.transform.position, _shootPoint.transform.rotation);
        ParticleSystem shootEffect = Instantiate(_prefabShoot, _shootPoint.transform.position, _shootPoint.transform.rotation);
        Destroy(shootEffect.gameObject, 1);

        _shootSound.Play();
        bullet.SetDamage(_enemy.Damage);
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
            _shootDelayCounter -= Time.fixedDeltaTime;
        }
    }
}