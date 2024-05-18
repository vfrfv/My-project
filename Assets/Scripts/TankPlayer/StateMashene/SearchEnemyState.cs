using System;
using System.Collections;
using UnityEngine;

public class SearchEnemyState : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;

    private Enemy _target;

    public event Action<Enemy> EnemyDetected;
    public event Action<Enemy> EnemyLost;

    private void Start()
    {
        StartCoroutine(StartScanning());
    }

    private IEnumerator StartScanning()
    {
        float amountDelay = 0.5f;
        var delay = new WaitForSeconds(amountDelay);

        while (_target == null)
        {
            Detect();

            yield return delay;
        }
    }

    private void Detect()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f, _mask);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                _target = enemy;
                EnemyDetected?.Invoke(enemy);
                return;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }
}
