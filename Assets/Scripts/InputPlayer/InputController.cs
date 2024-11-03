using Agava.WebUtility;
using UnityEngine;

namespace Tanks.TankPlayer.Movement
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;

        private InputsPlayer _inputsPlayer;

        private void Awake()
        {
            _inputsPlayer = new InputsPlayer();
        }

        private void OnEnable()
        {
            _inputsPlayer.Enable();
        }

        private void OnDisable()
        {
            _inputsPlayer.Disable();
        }

        public Vector2 GetInputDirection()
        {
            if (Device.IsMobile)
            {
                if (!_joystick.gameObject.activeSelf)
                {
                    _joystick.gameObject.SetActive(true);
                }

                return _joystick.Direction;
            }
            else
            {
                if (_joystick.gameObject.activeSelf)
                {
                    _joystick.gameObject.SetActive(false);
                }

                return _inputsPlayer.Player.Move.ReadValue<Vector2>();
            }
        }
    }
}