using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneFinal : MonoBehaviour
{
    [SerializeField] CameraManagement _cameraManagement;
    [SerializeField] SoundManager _soundManager;
    [SerializeField] private Enemy _boss;
    [SerializeField] private EnemyAttack _bossAttack;
    [SerializeField] private BoxCollider _playerBoxCollider;
    [SerializeField] private LevelManager _levelManager;

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
        _levelManager.Load();

        if (SceneManager.GetActiveScene().buildIndex == _levelManager.CurrentLevel)
        {
            _levelManager.CompleteLevel();
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