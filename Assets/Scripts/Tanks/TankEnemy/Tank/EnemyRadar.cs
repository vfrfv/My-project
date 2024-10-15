using Assets.Scripts.Tanks.TankPlayer;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tanks.TankEnemy.Tank
{
    public class EnemyRadar : MonoBehaviour
    {
        [SerializeField] private LayerMask _mask;
        [SerializeField] private LayerMask _obstacleMask;
        [SerializeField] private Enemy _enemy;

        private readonly float _fieldView = 15f;

        public float FieldView => _fieldView;

        private void OnEnable()
        {
            StartCoroutine(StartScanning());
        }

        private IEnumerator StartScanning()
        {
            float amountDelay = 0.3f;
            var delay = new WaitForSeconds(amountDelay);

            while (_enemy.Player == null)
            {
                Detect();

                yield return delay;
            }
        }

        private void Detect()
        {
            RaycastHit _1;

            Collider[] colliders = Physics.OverlapSphere(transform.position, _fieldView, _mask);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out Player player))
                {
                    if (!Physics.Raycast(
                        transform.position,
                        (player.transform.position - transform.position).normalized,
                        out _1,
                        _fieldView,
                        _obstacleMask,
                        queryTriggerInteraction: QueryTriggerInteraction.Collide))
                    {
                        _enemy.SetTarget(player);
                        return;
                    }
                }
            }
        }
    }
}