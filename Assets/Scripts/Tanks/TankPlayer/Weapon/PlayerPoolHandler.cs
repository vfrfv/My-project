using Bullet.PlayerBullet;
using UnityEngine;

namespace Tanks.TankPlayer.Weapon
{
    public class PlayerPoolHandler : MonoBehaviour
    {
        [SerializeField] private PlayerBullet _prefabBullet;

        private PlayerPoolBullet _pool;

        public PlayerPoolBullet Pool => _pool;

        private void Awake()
        {
            _pool = new PlayerPoolBullet(_prefabBullet);
        }
    }
}