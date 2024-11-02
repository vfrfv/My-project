using Tanks.TankPlayer;
using UnityEngine;

namespace Tanks.TankEnemy.Tank
{
    public class EnemyAttack : TankAttack
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private Enemy _enemy;

        public EnemyAttack() : base(3.0f) { }

        private void FixedUpdate()
        {
            if (_enemy.Target != null)
            {
                LookAtDirection(_enemy.Target.transform.position, transform);

                if (IsTurretFacingTarget(_enemy.Target.transform.position, transform))
                {
                    _weapon.Shoot();
                }
            }
        }
    }
}