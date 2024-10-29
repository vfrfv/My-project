using Tanks.TankEnemy.Tank.Weapon;
using UnityEngine;

namespace Tanks.TankEnemy.Tank
{
    public class EnemyAttack : TankAttack
    {
        [SerializeField] private EnemyWeapon _weapon;
        [SerializeField] private Enemy _enemy;

        public EnemyAttack() : base(3.0f) { }

        private void FixedUpdate()
        {
            if (_enemy.Player != null)
            {
                LookAtDirection(_enemy.Player.transform.position, transform);

                if (IsTurretFacingTarget(_enemy.Player.transform.position, transform))
                {
                    _weapon.Shoot();
                }
            }
        }
    }
}