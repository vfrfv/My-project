using System;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _flightSpeed = 7;

    private int _damage;

    public int Damage => _damage;

    public event Action<Bullet> Destroyed;

    protected void Update()
    {
        Fly();
    }

    protected void OnTriggerEnter(Collider other)
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

    protected virtual void Fly()
    {
        transform.Translate(Vector3.forward * _flightSpeed * Time.deltaTime);
    }
}