using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _flightSpeed = 7;
    [SerializeField] private int _damage;

    public int Damage => _damage;

    public event Action<Bullet> Destroyed;

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

        //if (other.gameObject.TryGetComponent(out Enemy enemy))
        //{

        //}
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}
