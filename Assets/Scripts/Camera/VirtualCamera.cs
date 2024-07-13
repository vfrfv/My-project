using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCamera : MonoBehaviour
{
    [SerializeField] private FlightTower _flightTower;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    private void Start()
    {
        _flightTower.Flew += ChangeTarget;
    }

    private void ChangeTarget()
    {
        _virtualCamera.Follow = _flightTower.transform;
        _virtualCamera.LookAt = _flightTower.transform;

        _flightTower.Flew -= ChangeTarget;
    }
}
