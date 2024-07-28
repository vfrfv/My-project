using System.Collections.Generic;
using UnityEngine;

public class UpgradeService
{
    private List<UnitConfig> _unitConfigs;
    private Player _player;

    public UpgradeService(List<UnitConfig> unitConfigs, Player player)
    {
        _unitConfigs = unitConfigs;
        _player = player;

    }

    public void Upgrade()
    {      
        _player.Init(_unitConfigs[1]);
    }
}
