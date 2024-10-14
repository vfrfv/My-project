using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyWeapon _weapon;
    [SerializeField] private Enemy _enemy;

    private float _angleThreshold = 3.0f;

    private void FixedUpdate()
    {
        if (_enemy.Player != null)
        {
            LookAtDirection(_enemy.Player);

            if (IsTurretFacingTarget(_enemy.Player))
            {
                _weapon.Shoot();
            }
        }
    }

    private bool IsTurretFacingTarget(Player player)
    {
        if (player != null)
        {
            Vector3 directionToTarget = player.transform.position - transform.position;
            float angle = Vector3.Angle(transform.forward, directionToTarget);

            return angle <= _angleThreshold;
        }

        return false;
    }

    private void LookAtDirection(Player player)
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }
}