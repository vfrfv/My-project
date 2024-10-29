using Tanks.TankEnemy.Tank;
using UnityEngine;

namespace Tanks.TankPlayer
{
    public class PlayerRadar : TankRadarBase
    {
        [SerializeField] private Player _player;

        protected override void SetTarget(Collider target)
        {
            if (target.TryGetComponent(out Enemy enemy))
            {
                _player.SetTarget(enemy);
            }
        }

        protected override bool IsValidTarget(Collider collider, out Collider target)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                target = collider;
                return true;
            }
            target = null;
            return false;
        }

        protected override float GetScanningDelay()
        {
            return 0.1f;
        }
    }
}