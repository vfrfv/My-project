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
            bool isMobile = Device.IsMobile;
            _joystick.gameObject.SetActive(isMobile);

            if (isMobile)
            {
                return _joystick.Direction;
            }
            else
            {
                return _inputsPlayer.Player.Move.ReadValue<Vector2>();
            }
        }
    }
}