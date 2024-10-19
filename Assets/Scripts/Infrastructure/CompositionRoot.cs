using Assets.Scripts.Bar;
using Assets.Scripts.Conservation;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Zones;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.Tanks.TankEnemy.Tank.Turret;
using Assets.Scripts.Tanks.TankPlayer;
using Cinemachine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private List<Zone> _zones = new List<Zone>();
        [SerializeField] private List<UnitConfig> _unitConfigs;

        [SerializeField] private SmoothBar _smoothHealthBar;
        [SerializeField] private SmoothBar _progressBar;
        [SerializeField] private ParticleSystem _upgradeEffect;
        [SerializeField] private AudioSource _upgradeSound;
        [SerializeField] private FlightTower _flightTower;

        private GameLoopService _loopService;
        private PlayerLevelProgressService _playerLevelProgressService;
        private UpgradeService _upgradeService;
        private PlayerPointsSaver _playerPointsSaver;

        private void Awake()
        {
            _upgradeService = new UpgradeService(_unitConfigs, _player, _upgradeSound, _upgradeEffect);
            _playerLevelProgressService = new PlayerLevelProgressService(_upgradeService);
            _loopService = new GameLoopService(_playerLevelProgressService, _upgradeService);
            _playerPointsSaver = new PlayerPointsSaver(_flightTower);

            var provider = _progressBar.AddComponent<ValueProvider>();
            provider.Init(_playerLevelProgressService, _progressBar);

            SubscribePumping();
            _player.Init(_unitConfigs[0]);
        }

        private void SubscribePumping()
        {
            foreach (var zone in _zones)
            {
                zone.Init(_loopService);
            }
        }
    }
}