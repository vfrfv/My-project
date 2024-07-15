using System;
using UnityEngine;

public class FlightTower : MonoBehaviour
{
    [SerializeField] private Transform _flightDirection;
    [SerializeField] private Enemy _bossEnemy;
    [SerializeField] private SmoothBar _smoothBar;

    private Rigidbody _rigidbody;
    private int _launchForce = 150;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    private void Start()
    {
        _bossEnemy.Died += LaunchTower;
    }

    public event Action Flew;

    private void LaunchTower(Enemy enemy)
    {
        _rigidbody.isKinematic = false;
        Flew?.Invoke();
        Fly();

        _bossEnemy.Died -= LaunchTower;
    }

    private void Fly()
    {
        gameObject.transform.localRotation = _flightDirection.localRotation;

        Debug.Log(_smoothBar.Value.Value * _launchForce);

        _rigidbody.AddRelativeForce(gameObject.transform.forward * (_smoothBar.Value.Value * _launchForce), ForceMode.Force);
    }
}
