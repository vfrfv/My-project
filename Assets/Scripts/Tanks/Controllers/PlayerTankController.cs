using UnityEngine;

namespace Tanks.TankPlayer.Movement
{
    public class PlayerTankController : MonoBehaviour
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private SoundController _soundController;
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private InputController _inputController;

        private void FixedUpdate()
        {
            Vector2 moveDirection = _inputController.GetInputDirection();
            bool isMoving = moveDirection != Vector2.zero;

            _movementController.Move(moveDirection);
            _movementController.Turn(moveDirection);

            _soundController.PlaySound(isMoving);
            _animationController.ControlAnimation(isMoving);
        }
    }
}