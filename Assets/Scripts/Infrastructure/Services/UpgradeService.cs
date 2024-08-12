using System.Collections.Generic;
using UnityEngine;

public class UpgradeService
{
    private List<UnitConfig> _unitConfigs;
    private Player _player;
    private AudioSource _audioSource;
    private ParticleSystem _particleSystem;
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
            Object.Instantiate(_particleSystem, _player.transform.position, Quaternion.identity);
            _audioSource.Play();

            _player.Init(nextConfig);
        }
    }

    private UnitConfig GetFollowingConfiguration()
    {
        if (_currentConfig < _unitConfigs.Count -1)
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

    public bool IsMaxLevel()
    {
        return _currentConfig >= _unitConfigs.Count - 1;
    }
}
