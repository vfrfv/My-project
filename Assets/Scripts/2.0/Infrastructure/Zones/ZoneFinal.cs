using System;
using UnityEngine;

public class ZoneFinal : MonoBehaviour
{
    [SerializeField] CameraManagement _camera;
    [SerializeField] private Enemy _boss;
    [SerializeField] private SmoothBar _enemyHealthBar;

    public event Action PlayerInZone;

    private void Awake()
    {
        _boss.Died += SwitchCameraToTowerBoss;
    }

    private void Start()
    {
        _enemyHealthBar.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MovementPlayerTank movementPlayerTank))
        {
            _camera.SwitchToBoss();
            movementPlayerTank.enabled = false;
            _enemyHealthBar.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        _boss.Died -= SwitchCameraToTowerBoss;
    }

    private void SwitchCameraToTowerBoss(Enemy enemy)
    {
        _camera.SwitchToTowerBoss();
    }
}
