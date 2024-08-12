using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ZoneFinal : MonoBehaviour
{
    [SerializeField] CameraManagement _cameraManagement;
    [SerializeField] SoundManager _soundManager;
    [SerializeField] private Enemy _boss;
    [SerializeField] private EnemyAttack _bossAttack;
    [SerializeField] private BoxCollider _playerBoxCollider;

    public event Action PlayerInZone;

    private void Awake()
    {
        _boss.Died += SwitchCameraToTowerBoss;
        _boss.Died += DisableTakingPlayerDamage;

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
        _boss.Died += DisableTakingPlayerDamage;
    }

    private IEnumerator StartBattle(Player player)
    {
        yield return new WaitForSeconds(2);

        _boss.SetTarget(player);
        player.SetTarget(_boss);
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
