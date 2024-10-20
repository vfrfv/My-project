using Conservation;
using Manager.Camers;
using Manager.Sounds;
using System;
using System.Collections;
using Tanks.TankEnemy.Tank;
using Tanks.TankPlayer;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Zones
{
    public class ZoneFinal : MonoBehaviour
    {
        [SerializeField] private CameraManagement _cameraManagement;
        [SerializeField] private SoundManager _soundManager;
        [SerializeField] private Enemy _boss;
        [SerializeField] private EnemyAttack _bossAttack;
        [SerializeField] private BoxCollider _playerBoxCollider;
        [SerializeField] private ProgressSaver _progressSaver;

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

        private void OpenNextLevel(Enemy _)
        {
            _progressSaver.Load();

            if (SceneManager.GetActiveScene().buildIndex == _progressSaver.CurrentLevel)
            {
                _progressSaver.CompleteLevel();
            }
        }

        private void SwitchCameraToTowerBoss(Enemy _)
        {
            _cameraManagement.SwitchToTowerBoss();
            _bossAttack.enabled = false;
        }

        private void DisableTakingPlayerDamage(Enemy _)
        {
            _playerBoxCollider.enabled = false;
        }
    }
}