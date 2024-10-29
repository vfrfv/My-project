using System.Collections;
using UnityEngine;

public abstract class TankRadarBase : MonoBehaviour
{
    [SerializeField] protected LayerMask _mask;
    [SerializeField] protected LayerMask _obstacleMask;
    protected readonly float _fieldView = 15f;

    public float FieldView => _fieldView;

    protected abstract void SetTarget(Collider target);

    private void OnEnable()
    {
        StartCoroutine(StartScanning());
    }

    protected IEnumerator StartScanning()
    {
        float amountDelay = GetScanningDelay();
        var delay = new WaitForSeconds(amountDelay);

        while (true)
        {
            Detect();
            yield return delay;
        }
    }

    protected virtual float GetScanningDelay()
    {
        return 0.1f; // Задержка по умолчанию для сканирования
    }

    private void Detect()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _fieldView, _mask);
        RaycastHit hit;

        foreach (var collider in colliders)
        {
            if (IsValidTarget(collider, out var target))
            {
                if (!Physics.Raycast(
                    transform.position,
                    (target.transform.position - transform.position).normalized,
                    out hit,
                    _fieldView,
                    _obstacleMask,
                    QueryTriggerInteraction.Collide))
                {
                    SetTarget(collider);
                    return; // Выход после нахождения первой допустимой цели
                }
            }
        }
    }

    protected abstract bool IsValidTarget(Collider collider, out Collider target);
}
