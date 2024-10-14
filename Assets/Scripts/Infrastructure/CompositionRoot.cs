using Cinemachine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    private LevelProgressService _levelProgressService;
    private UpgradeService _upgradeService;
    private PlayerPointsManager _playerPointsManager;

    private void Awake()
    {
        _upgradeService = new UpgradeService(_unitConfigs, _player, _upgradeSound, _upgradeEffect);
        _levelProgressService = new LevelProgressService(_upgradeService);
        _loopService = new GameLoopService(_levelProgressService, _upgradeService);
        _playerPointsManager = new PlayerPointsManager(_flightTower);

        var provider = _progressBar.AddComponent<ValueProvider>();
        provider.Init(_levelProgressService, _progressBar);

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
