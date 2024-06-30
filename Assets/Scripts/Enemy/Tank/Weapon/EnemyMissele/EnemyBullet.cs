using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
   [SerializeField] private float flightSpeed = 7;

    public event Action<EnemyBullet> Destroyed;

    private void Update()
    {
        transform.Translate(Vector3.forward * flightSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            Destroyed?.Invoke(this);
        }
    }
}