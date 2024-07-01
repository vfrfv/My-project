using System.Collections;
using UnityEngine;

public class PlayerRadar : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private Player _player;

    private float _fieldView = 15f;

    public float FieldView => _fieldView;

    private void OnEnable()
    {
        StartCoroutine(StartScanning());
    }

    private IEnumerator StartScanning()
    {
        float amountDelay = 0.5f;
        var delay = new WaitForSeconds(amountDelay);

        while (_player.Target == null)
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
            if (collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                Debug.Log(enemy.gameObject.name);

                //Vector3 directionToEnemy = (enemy.transform.position - transform.position).normalized;
                //float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                if (!Physics.Linecast(transform.position, enemy.transform.position, out RaycastHit hit, _obstacleMask))
                {
                    _player.SetTarget(enemy);
                    return;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 15f);
    }
}
