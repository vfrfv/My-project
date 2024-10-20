using Bullet;
using System.Collections;
using Tanks.TankPlayer;
using UnityEngine;

namespace Tanks.TankPlayer.Weapon
{
    [RequireComponent(typeof(PlayerPoolHandler))]
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private ParticleSystem _prefabShoot;
        [SerializeField] private AudioSource _shootSound;

        private Transform _shootPoint;
        private float _shootDelayCounter = 0;
        private readonly float _shootDelayInSeconds = 1;
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

            BulletBase bullet = _poolHandler.Pool.GiveMissile(_shootPoint.transform.position, _shootPoint.transform.rotation);
            ParticleSystem shootEffect = Instantiate(_prefabShoot, _shootPoint.transform.position, _shootPoint.transform.rotation);
            Destroy(shootEffect.gameObject, 1);

            _shootSound.Play();
            bullet.SetDamage(_player.Damage);
            bullet.Destroyed += ReturnMissile;

            StartCoroutine(StartCooldown());
        }

        private void ReturnMissile(BulletBase bullet)
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
}