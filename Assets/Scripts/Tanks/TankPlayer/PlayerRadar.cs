using System.Collections;
using Tanks.TankEnemy.Tank;
using UnityEngine;

namespace Tanks.TankPlayer
{
    public class PlayerRadar : MonoBehaviour
    {
        [SerializeField] private LayerMask _mask;
        [SerializeField] private LayerMask _obstacleMask;
        [SerializeField] private Player _player;

        private readonly float _fieldView = 15f;

        public float FieldView => _fieldView;

        private void OnEnable()
        {
            StartCoroutine(StartScanning());
        }

        private IEnumerator StartScanning()
        {
            float amountDelay = 0.1f;
            var delay = new WaitForSeconds(amountDelay);

            while (true)
            {
                Detect();
                yield return delay;
            }
        }

        private void Detect()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _fieldView, _mask);
            Enemy closestTarget = null;
            float closestDistance = Mathf.Infinity;

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out Enemy target))
                {
                    if (!Physics.Raycast(
                        transform.position,
                        (target.transform.position - transform.position).normalized,
                        out RaycastHit hit,
                        15,
                        _obstacleMask,
                        queryTriggerInteraction: QueryTriggerInteraction.Collide))
                    {
                        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

                        if (distanceToTarget < closestDistance)
                        {
                            closestDistance = distanceToTarget;
                            closestTarget = target;
                        }
                    }
                }
            }

            if (closestTarget != null)
            {
                _player.SetTarget(closestTarget);
            }
        }
    }
}