using Tanks.TankPlayer;
using UnityEngine;

namespace Tanks.TankEnemy.Tank
{
    public class EnemyRadar : TankRadarBase
    {
        [SerializeField] private Enemy _enemy;

        protected override void SetTarget(Collider target)
        {
            if (target.TryGetComponent(out Player player))
            {
                _enemy.SetTarget(player);
            }
        }

        protected override bool IsValidTarget(Collider collider, out Collider target)
        {
            if (collider.TryGetComponent(out Player player))
            {
                target = collider;
                return true;
            }
            target = null;
            return false;
        }

        protected override float GetScanningDelay()
        {
            return 0.3f;
        }

        private void Update()
        {
            if (_enemy.Player != null)
            {
                StopCoroutine(StartScanning());
            }
        }
    }
}