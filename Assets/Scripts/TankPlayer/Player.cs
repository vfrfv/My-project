using UnityEngine;

public class Player : MonoBehaviour
{
    private float _health = 5f;
    private Enemy _target;

    public Enemy Target => _target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyMissile enemyMissile) ||
            other.TryGetComponent(out ArtaMissile artaMissile))
        {
            TakeDamage();
        }
    }

    private void Update()
    {
        Debug.Log($"ХП Игрока {_health}");
    }

    public void SetTarget(Enemy enemy)
    {
        _target = enemy;
    }

    public void LoseTarget()
    {
        _target = null;
    }

    private void TakeDamage()
    {
        if (_health <= 0)
        {
            Die();
        }
        else
        {
            _health--;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
