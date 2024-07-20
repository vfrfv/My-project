using System;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private int _flightSpeed = 7;
    [SerializeField] private int _damage;

    public int Damage => _damage;

    public event Action<PlayerBullet> Destroyed;

    private void Update()
    {
        transform.Translate(Vector3.forward * _flightSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            Destroyed?.Invoke(this);
        }
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    private void Fly()
    {
        transform.Translate(Vector3.forward * _flightSpeed * Time.deltaTime);
    }
}
