using Infrastructure.Barriers;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using Tanks.TankEnemy;
using UnityEngine;

namespace Infrastructure.Zones
{
    public class Zone : MonoBehaviour
    {
        [SerializeField] private Barrier _barrier;

        private List<Enemy> _enemies = new List<Enemy>();
        private GameLoopService _loopService;

        public List<Enemy> Enemies => _enemies;

        public event Action EnemiesAreOver;
        public event Action NumberEnemiesHasChanged;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                if (_enemies.Contains(enemy) == false)
                {
                    _enemies.Add(enemy);
                    NumberEnemiesHasChanged?.Invoke();
                    enemy.Died += RemoveEnemy;
                    _loopService.AddPlayerProgress(enemy);

                    UpdateBarrierState();
                }
            }
        }

        public void Init(GameLoopService gameLoopService)
        {
            _loopService = gameLoopService;
        }

        private void RemoveEnemy(Enemy enemy)
        {
            enemy.Died -= RemoveEnemy;
            _enemies.Remove(enemy);
            NumberEnemiesHasChanged?.Invoke();

            UpdateBarrierState();
        }

        private void UpdateBarrierState()
        {
            if (_enemies.Count <= 0)
            {
                EnemiesAreOver?.Invoke();
                _barrier.OpenZone();
            }
            else
            {
                _barrier.CloseZone();
            }
        }
    }
}