using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _flightSpeed = 7;
    [SerializeField] private int _damage;

    public int Damage => _damage;

    public event Action<EnemyBullet> Destroyed;

    private void Update()
    {
        Fly();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            Destroyed?.Invoke(this);
        }
    }

    private void Fly()
    {
        transform.Translate(Vector3.forward * _flightSpeed * Time.deltaTime);
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}
