using Tanks.TankEnemy.Tank;
using Tanks.TankPlayer.Weapon;
using UnityEngine;

namespace Tanks.TankPlayer
{
    public class PlayerAttack : TankAttack
    {
        [SerializeField] private PlayerWeapon _weapon;
        [SerializeField] private Player _player;
        private Transform _tower;

        public PlayerAttack() : base(5.0f) { }

        private void FixedUpdate()
        {
            if (_player.Target != null)
            {
                LookAtDirection(_player.Target.transform.position, _tower);

                if (IsTurretFacingTarget(_player.Target.transform.position, _tower))
                {
                    _weapon.Shoot();
                }
            }
        }

        public void InstallTower(Transform tower)
        {
            _tower = tower;
        }
    }
}