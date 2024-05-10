using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private float flightSpeed = 15;

    public event Action<Missile> Destroyed;

    private void Update()
    {
        transform.Translate(Vector3.forward * flightSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroyed?.Invoke(this);
        }
    }
}
