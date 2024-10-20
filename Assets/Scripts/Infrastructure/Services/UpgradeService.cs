using ScriptableObjects;
using System.Collections.Generic;
using Tanks.TankPlayer;
using UnityEngine;

namespace Infrastructure.Services
{
    public class UpgradeService
    {
        private List<UnitConfig> _unitConfigs;
        private readonly Player _player;
        private readonly AudioSource _audioSource;
        private readonly ParticleSystem _particleSystem;
        private int _currentConfig = 0;

        public UpgradeService(List<UnitConfig> unitConfigs, Player player, AudioSource audioSource, ParticleSystem particleSystem)
        {
            _unitConfigs = unitConfigs;
            _player = player;
            _audioSource = audioSource;
            _particleSystem = particleSystem;
        }

        public void Upgrade()
        {
            UnitConfig nextConfig = GetFollowingConfiguration();

            if (nextConfig != null)
            {
                ParticleSystem particleSystem = Object.Instantiate(_particleSystem, _player.transform.position, Quaternion.identity);
                _audioSource.Play();

                _player.Init(nextConfig);
            }
        }

        public bool IsMaxLevel()
        {
            return _currentConfig >= _unitConfigs.Count - 1;
        }

        private UnitConfig GetFollowingConfiguration()
        {
            if (_currentConfig < _unitConfigs.Count - 1)
            {
                _currentConfig++;
                UnitConfig config = _unitConfigs[_currentConfig];

                return config;
            }
            else
            {
                return null;
            }
        }
    }
}