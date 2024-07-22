using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCamera : MonoBehaviour
{
    [SerializeField] private FlightTower _flightTower;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private EnemyAttack _enemyAttack;

    private void Start()
    {
        _flightTower.Flew += ChangeTarget;
    }

    private void ChangeTarget()
    {
        _virtualCamera.Follow = _enemyAttack.transform;
        _virtualCamera.LookAt = _enemyAttack.transform;

        _flightTower.Flew -= ChangeTarget;
    }
}
