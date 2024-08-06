using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerWeapon _weapon;
    [SerializeField] private Player _player;

    private float _turningSpeed = 8;
    private float _angleThreshold = 5.0f;
    private Transform _tower;

    private void FixedUpdate()
    {
        if (_player.Target != null)
        {
            LookAtDirection(_player.Target);

            if (IsTurretFacingTarget(_player.Target))
            {
                _weapon.Shoot();
            }
        }
    }

    public void InstallTower(Transform tower)
    {
        _tower = tower;
    }

    private bool IsTurretFacingTarget(Enemy enemy)
    {
        if (enemy != null)
        {
            Vector3 directionToTarget = enemy.transform.position - _tower.transform.position;
            float angle = Vector3.Angle(_tower.transform.forward, directionToTarget);

            return angle <= _angleThreshold;
        }

        return false;
    }

    private void LookAtDirection(Enemy enemy)
    {
        if (enemy != null)
        {
            Vector3 direction = enemy.transform.position - _tower.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _tower.transform.rotation = targetRotation;
        }
    }
}
