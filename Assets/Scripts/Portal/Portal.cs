using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] NavMeshAgent _agent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _agent.enabled = false;

            player.transform.position = _point.position;

            _agent.enabled = true;
        }
    }
}
