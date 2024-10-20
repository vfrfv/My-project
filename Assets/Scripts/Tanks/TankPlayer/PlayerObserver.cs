using Infrastructure.Zones;
using System.Collections;
using Tanks.TankPlayer.Movement;
using UnityEngine;

namespace Tanks.TankPlayer
{
    public class PlayerObserver : MonoBehaviour
    {
        [SerializeField] private PlayerRadar _playerRadar;
        [SerializeField] private PlayerAttack _playerAttask;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerTankController _playerTankController;
        [SerializeField] private AnimationController _playerAnimationController;

        private Coroutine _coroutine;

        private void Start()
        {
            _coroutine = StartCoroutine(DestroyEnemies());
            _playerTankController.enabled = true;
        }

        private IEnumerator DestroyEnemies()
        {
            while (true)
            {
                if (_player.Target != null)
                {
                    if (Vector3.Distance(transform.position, _player.Target.transform.position) < _playerRadar.FieldView)
                    {
                        _playerRadar.enabled = false;
                        _playerAttask.enabled = true;
                    }
                    else
                    {
                        _player.LoseTarget();
                    }
                }
                else
                {
                    _playerRadar.enabled = true;
                    _playerAttask.enabled = false;
                }

                yield return null;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<ZoneFinal>())
            {
                StopCoroutine(_coroutine);

                _playerRadar.enabled = false;
                _playerTankController.enabled = false;
                _playerAnimationController.DisableMotionAnimation();

                _playerAttask.enabled = true;
            }
        }
    }
}