using System.Collections;
using UnityEngine;

namespace Tanks
{
    public class Radar : MonoBehaviour
    {
        [SerializeField] private TankType _type;
        [SerializeField] private LayerMask _mask;
        [SerializeField] private LayerMask _obstacleMask;
        [SerializeField] private Tanks.TankBase _tank;

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

            while (_tank.Target == null)
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
                if (collider.TryGetComponent(out TankBase tank))
                {
                    if (tank.Type == _type)
                    {
                        if (!Physics.Raycast(
                        transform.position,
                        (tank.transform.position - transform.position).normalized,
                        out _1,
                        _fieldView,
                        _obstacleMask,
                        queryTriggerInteraction: QueryTriggerInteraction.Collide))
                        {
                            _tank.SetTarget(tank);
                            return;
                        }
                    }
                }
            }
        }
    }
}