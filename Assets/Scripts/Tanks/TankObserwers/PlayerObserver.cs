using Infrastructure.Zones;
using Tanks.Controllers;
using UnityEngine;

namespace Tanks.TankObserwers
{
    public class PlayerObserver : TankObserver
    {
        [SerializeField] private PlayerTankInput _playerTankController;
        [SerializeField] private TankAnimation _playerAnimationController;

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