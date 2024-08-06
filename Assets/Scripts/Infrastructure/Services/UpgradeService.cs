using System.Collections.Generic;
using UnityEngine;

public class UpgradeService
{
    private List<UnitConfig> _unitConfigs;
    private Player _player;
    private AudioSource _audioSource;
    private ParticleSystem _particleSystem;

    public UpgradeService(List<UnitConfig> unitConfigs, Player player, AudioSource audioSource, ParticleSystem particleSystem)
    {
        _unitConfigs = unitConfigs;
        _player = player;
        _audioSource = audioSource;
        _particleSystem = particleSystem;
    }

    public void Upgrade()
    {
        Object.Instantiate(_particleSystem, _player.transform.position, Quaternion.identity);
        _audioSource.Play();
        _player.Init(_unitConfigs[1]);
    }
}
