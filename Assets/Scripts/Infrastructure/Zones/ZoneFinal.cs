using System;
using System.Collections;
using UnityEngine;

public class ZoneFinal : MonoBehaviour
{
    [SerializeField] CameraManagement _cameraManagement;
    [SerializeField] private Enemy _boss;
    [SerializeField] private EnemyAttack _bossAttack;

    public event Action PlayerInZone;

    private void Awake()
    {
        _boss.Died += SwitchCameraToTowerBoss;

        _bossAttack.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _bossAttack.enabled = true;
            StartCoroutine(StartBattle(player));
            _cameraManagement.SwitchToBoss();
        }
    }

    private void OnDisable()
    {
        _boss.Died -= SwitchCameraToTowerBoss;
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
}
