using UnityEngine;
using UnityEngine.AI;

namespace Tanks.TankPlayer.Movement
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float _speed = 100;
        [SerializeField] private float _turningSpeed = 8f;
        [SerializeField] private NavMeshAgent _meshAgent;

        public void Move(Vector2 direction)
        {
            Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
            _meshAgent.destination = transform.position + moveDirection * _speed * Time.fixedDeltaTime;
        }

        public void Turn(Vector2 direction)
        {
            if (direction != Vector2.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _turningSpeed * Time.deltaTime);
            }
        }
    }
}