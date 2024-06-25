using System.Collections.Generic;
using UnityEngine;

public class UpgradeService
{
    private List<UnitConfig> _unitConfigs;
    private Player _player;
    private IndicateTarget _indicateTarget;

    public UpgradeService(List<UnitConfig> unitConfigs, Player player, IndicateTarget indicateTarget)
    {
        _unitConfigs = unitConfigs;
        _player = player;
        _indicateTarget = indicateTarget;
    }

    public void Upgrade()
    {
        var player = Object.Instantiate(_unitConfigs[1].UnitPrefab, _player.transform.position, _player.transform.rotation);
        Object.Destroy(_player.gameObject);
        _player = player.GetComponent<Player>();
        _player.Init(_unitConfigs[1].GetStats());
        _indicateTarget.InstallNewPlayerCamera(_player);
        _indicateTarget.InstallNewPlayerArta(_player);
    }
}
