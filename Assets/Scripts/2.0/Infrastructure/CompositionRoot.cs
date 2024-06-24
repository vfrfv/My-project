using System.Collections.Generic;
using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    //[SerializeField] private UnitConfig _playerConfig;

    [SerializeField] private Player _player;
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private List<UnitConfig> _unitConfigs;

    private GameLoopService _loopService;
    private LevelProgressService _levelProgressService;
    private UpgradeService _upgradeService;
    //private FragmentCounter _fragmentCounter;

    private void Awake()
    {
        _upgradeService = new UpgradeService(_unitConfigs, _player);
        _levelProgressService = new LevelProgressService(_enemies);
        _loopService = new GameLoopService(_levelProgressService, _upgradeService);
        //_fragmentCounter = new FragmentCounter(_enemies);   
    }

    private void Start()
    {
        _player.Init(_unitConfigs[0].GetStats());
    }
}
