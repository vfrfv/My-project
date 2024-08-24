using System.Collections;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private Enemy _enemy;

    private float _fieldView = 15f;

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
        Collider[] colliders = Physics.OverlapSphere(transform.position, _fieldView, _mask);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<Player>(out Player player))
            {
                if (!Physics.Raycast(
                    transform.position,
                    (player.transform.position - transform.position).normalized,
                    out RaycastHit hit,
                    15,
                    _obstacleMask,
                    queryTriggerInteraction: QueryTriggerInteraction.Collide))
                {
                    _enemy.SetTarget(player);
                    return;
                }
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, _fieldView);
    //}
}
