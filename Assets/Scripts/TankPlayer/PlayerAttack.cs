using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerWeapon _weapon;
    [SerializeField] private LayerMask _enemy;

    [SerializeField] private Player _player;

    private float _turningSpeed = 8;
    private float _angleThreshold = 5.0f;

    private void FixedUpdate()
    {
        //Перенести всё в FixedUpdate и дельтатаймы и фиксы, расчеты должны операться ны фиксыдельтатайм

        if (_player.Target != null)
        {
            LookAtDirection(_player.Target);

            if (IsTurretFacingTarget(_player.Target))
            {
                _weapon.Shoot();
            }
        }
    }

    private bool IsTurretFacingTarget(Enemy enemy)
    {
        if (enemy != null)
        {
            Vector3 directionToTarget = enemy.transform.position - transform.position;
            float angle = Vector3.Angle(transform.forward, directionToTarget);

            return angle <= _angleThreshold;
        }

        return false;
    }

    private void LookAtDirection(Enemy enemy)
    {
        if (enemy != null)
        {
            Vector3 direction = enemy.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _turningSpeed * Time.fixedDeltaTime);
        }
    }
}
