using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    //[SerializeField] private List<Enemy> _enemies;
    [SerializeField] private List<Zone> _zones = new List<Zone>();
    [SerializeField] private List<UnitConfig> _unitConfigs;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private ArtaAttack _artaAttack;
    [SerializeField] private Barrier _barrier;
    [SerializeField] private SmoothHealthBar _smoothHealthBar;

    private IndicateTarget _indicateTarget;
    private GameLoopService _loopService;
    private LevelProgressService _levelProgressService;
    private UpgradeService _upgradeService;
    //private ZoneService _zoneService;

    private void Awake()
    {
        _indicateTarget = new IndicateTarget(_camera, _artaAttack, _smoothHealthBar);  
        _upgradeService = new UpgradeService(_unitConfigs, _player, _indicateTarget);
        _levelProgressService = new LevelProgressService();
        //_zoneService = new ZoneService(_zones);
        _loopService = new GameLoopService(_levelProgressService, _upgradeService, /*_zoneService,*/ _barrier);
       
        foreach (var zone in _zones)
        {
            zone.Init(_loopService);
        }

        _player.Init(_unitConfigs[0].GetStats());
    }

    private void Start()
    {
        
    }


}
