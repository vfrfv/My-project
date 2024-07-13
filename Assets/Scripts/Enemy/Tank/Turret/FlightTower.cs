using System;
using System.Collections;
using UnityEngine;

public class FlightTower : MonoBehaviour
{
    [SerializeField] private Transform _flightDirection;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    public event Action Flew;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.isKinematic = false;
            Flew?.Invoke();
            Fly();
        }
    }

    private void Fly()
    {
        gameObject.transform.localRotation = _flightDirection.localRotation;
        _rigidbody.AddRelativeForce(gameObject.transform.forward * 1000, ForceMode.Force);
    }
}
