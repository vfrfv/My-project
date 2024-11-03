using Tanks.TankEnemy.Tank;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Tanks.TankPlayer
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private TankType _type;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private TankBase _tank;
        [SerializeField] private readonly float _angleThreshold = 5.0f;
        [SerializeField] private Transform _tower;

        private void FixedUpdate()
        {
            if (_tank.Target != null)
            {
                if(_tank.Target.Type == _type)
                {
                    LookAtDirection(_tank.Target);

                    if (IsTurretFacingTarget(_tank.Target))
                    {
                        _weapon.Shoot();
                    }
                } 
            }
        }

        public void InstallTower(Transform tower)
        {
            _tower = tower;
        }

        private bool IsTurretFacingTarget(TankBase tank)
        {
            if (tank != null)
            {
                Vector3 directionToTarget = tank.transform.position - _tower.transform.position;
                float angle = Vector3.Angle(_tower.transform.forward, directionToTarget);

                return angle <= _angleThreshold;
            }

            return false;
        }

        private void LookAtDirection(TankBase tank)
        {
            if (tank != null)
            {
                Vector3 direction = tank.transform.position - _tower.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                _tower.transform.rotation = targetRotation;
            }
        }
    }
}