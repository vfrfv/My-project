using Infrastructure.Zones;
using Tanks.TankEnemy.Tank;
using Tanks.TankPlayer.Movement;
using UnityEngine;

namespace Tanks.TankPlayer
{
    public class PlayerObserver : TankObserver
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
}