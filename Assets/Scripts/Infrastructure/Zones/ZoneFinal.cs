using Assets.Scripts.Manager.Camers;
using Assets.Scripts.Manager.Sounds;
using Assets.Scripts.Tanks.TankEnemy.Tank;
using Assets.Scripts.Tanks.TankPlayer;
using Conservation;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.Zones
{
    public class ZoneFinal : MonoBehaviour
    {
        [SerializeField] CameraManagement _cameraManagement;
        [SerializeField] SoundManager _soundManager;
        [SerializeField] private Enemy _boss;
        [SerializeField] private EnemyAttack _bossAttack;
        [SerializeField] private BoxCollider _playerBoxCollider;
        [SerializeField] private ProgressSaver _progressSaver;

        public event Action PlayerInZone;

        private void Awake()
        {
            _boss.Died += SwitchCameraToTowerBoss;
            _boss.Died += DisableTakingPlayerDamage;
            _boss.Died += OpenNextLevel;

            _bossAttack.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                _bossAttack.enabled = true;
                StartCoroutine(StartBattle(player));
                _cameraManagement.SwitchToBoss();
                _soundManager.TurnOnBossBattle();
            }
        }

        private void OnDisable()
        {
            _boss.Died -= SwitchCameraToTowerBoss;
            _boss.Died -= DisableTakingPlayerDamage;
            _boss.Died -= OpenNextLevel;
        }

        private IEnumerator StartBattle(Player player)
        {
            yield return new WaitForSeconds(2);

            _boss.SetTarget(player);
            player.SetTarget(_boss);
        }

        private void OpenNextLevel(Enemy enemy)
        {
            _progressSaver.Load();

            if (SceneManager.GetActiveScene().buildIndex == _progressSaver.CurrentLevel)
            {
                _progressSaver.CompleteLevel();
            }
        }

        private void SwitchCameraToTowerBoss(Enemy enemy)
        {
            _cameraManagement.SwitchToTowerBoss();
            _bossAttack.enabled = false;
        }

        private void DisableTakingPlayerDamage(Enemy enemy)
        {
            _playerBoxCollider.enabled = false;
        }
    }
}