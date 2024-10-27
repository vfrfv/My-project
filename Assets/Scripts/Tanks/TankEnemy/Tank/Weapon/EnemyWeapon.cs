using Bullet;
using System.Collections;
using UnityEngine;

namespace Tanks.TankEnemy.Tank.Weapon
{
    public class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private ParticleSystem _prefabShoot;
        [SerializeField] private AudioSource _shootSound;
        [SerializeField] private EnemyPoolHandler _poolHandler;

        private float _shootDelayCounter = 0;
        private float _shootDelayInSeconds;

        public bool CanShoot => _shootDelayCounter <= 0;

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

            BulletBase bullet = _poolHandler.Pool.GiveMissile(_shootPoint.transform.position, _shootPoint.transform.rotation);
            ParticleSystem shootEffect = Instantiate(_prefabShoot, _shootPoint.transform.position, _shootPoint.transform.rotation);
            Destroy(shootEffect.gameObject, 1);

            _shootSound.Play();
            bullet.SetDamage(_enemy.Damage);
            bullet.Destroyed += ReturnMissile;

            StartCoroutine(StartCooldown());
        }

        private void ReturnMissile(BulletBase bullet)
        {
            _poolHandler.Pool.ReleaseMissile(bullet);
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
}