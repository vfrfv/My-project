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
        var player = Object.Instantiate(_unitConfigs[1].UnitPrefab, _player.transform.position, _player.transform.rotation); // Builder (строитель)
        Object.Destroy(_player.gameObject);// Builder (строитель)

        _player = player.GetComponent<Player>();
        _player.Init(_unitConfigs[1].GetStats());

        _indicateTarget.BindPlayerToCamera(_player);
        _indicateTarget.BindPlayerToArta(_player);
        _indicateTarget.BindPlayerToHealthBar(_player);
    }
}
