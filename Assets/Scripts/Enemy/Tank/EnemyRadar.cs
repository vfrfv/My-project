using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;

   [SerializeField]  private Enemy _enemy;
    private float _fieldView = 10f;

    public float FieldView => _fieldView;

    //private void Awake()
    //{
    //    _enemy = GetComponent<Enemy>();
    //}

    private void OnEnable()
    {
        StartCoroutine(StartScanning());

        Debug.Log("vv");
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

    private void Detect()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _fieldView, _mask);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<Player>(out Player player))
            {
                _enemy.SetPlayer(player);
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
