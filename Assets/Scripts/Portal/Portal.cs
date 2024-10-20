using Tanks.TankPlayer;
using UnityEngine;
using UnityEngine.AI;

namespace Portal
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Transform _point;
        [SerializeField] private NavMeshAgent _agent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                _agent.enabled = false;

                player.transform.position = _point.position;

                _agent.enabled = true;
            }
        }
    }
}