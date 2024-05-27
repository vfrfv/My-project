using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRadar : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;

    [SerializeField] private Player _player;
    private float _fieldView = 15f;

    public float FieldView => _fieldView;

    //private void Awake()
    //{
    //    _player = GetComponent<Player>();
    //}

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
                _player.SetTarget(enemy);              
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
