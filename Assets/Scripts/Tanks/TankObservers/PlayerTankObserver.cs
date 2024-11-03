using Infrastructure.Zones;
using System.Collections;
using System.Collections.Generic;
using Tanks.TankEnemy.Tank;
using Tanks.TankPlayer;
using Tanks.TankPlayer.Movement;
using UnityEngine;

public class PlayerTankObserver : TankObserver
{
    [SerializeField] private PlayerTankController _playerTankController;
    [SerializeField] private AnimationController _playerAnimationController;

    private void Start()
    {
        base.Start();
        _playerTankController.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ZoneFinal>())
        {
            StopCoroutine(_coroutine);

            _radar.enabled = false;
            _playerTankController.enabled = false;
            _playerAnimationController.DisableMotionAnimation();

            _attask.enabled = true;
        }
    }
}
