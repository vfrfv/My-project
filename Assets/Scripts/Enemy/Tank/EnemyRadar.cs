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
        float amountDelay = 0.5f;
        var delay = new WaitForSeconds(amountDelay);

        while (_enemy.Player == null)
        {
            Detect();

            yield return delay;
        }
    }

    public void InstallFieldView(float fieldView)
    {
        _fieldView = fieldView;
    }

    private void Detect()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _fieldView, _mask);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<Player>(out Player player))
            {
                if (!Physics.Linecast(transform.position, player.transform.position, out RaycastHit hit, _obstacleMask))
                {
                    _enemy.SetPlayer(player);
                    return;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }
}
