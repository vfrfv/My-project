using System;
using UnityEngine;

namespace Bullet
{
    public abstract class BulletBase : MonoBehaviour
    {
        [SerializeField] private float _flightSpeed = 7;

        private int _damage;

        public int Damage => _damage;

        public event Action<BulletBase> Destroyed;

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

        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        private void Fly()
        {
            transform.Translate(Vector3.forward * _flightSpeed * Time.deltaTime);
        }
    }
}