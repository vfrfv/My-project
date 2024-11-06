using InputPlayer;
using UnityEngine;

namespace Tanks.Controllers
{
    public class PlayerTankInput : MonoBehaviour
    {
        [SerializeField] private TankMover _movementController;
        [SerializeField] private TankSound _soundController;
        [SerializeField] private TankAnimation _animationController;
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