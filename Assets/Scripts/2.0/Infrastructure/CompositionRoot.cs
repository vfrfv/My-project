using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private List<UnitConfig> _unitConfigs;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private ArtaAttack _artaAttack;
    [SerializeField] private SmoothHealthBar _healthBar;

    private IndicateTarget _indicateTarget;
    private GameLoopService _loopService;
    private LevelProgressService _levelProgressService;
    private UpgradeService _upgradeService;

    private void Awake()
    {
        _indicateTarget = new IndicateTarget(_camera, _artaAttack);  
        _upgradeService = new UpgradeService(_unitConfigs, _player, _indicateTarget);
        _levelProgressService = new LevelProgressService(_enemies);
        _loopService = new GameLoopService(_levelProgressService, _upgradeService);
    }

    private void Start()
    {
        _player.Init(_unitConfigs[0].GetStats());
        _healthBar.Init(_player);
    }
}
