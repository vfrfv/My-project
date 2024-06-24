using System.Collections.Generic;
using UnityEngine;

public class UpgradeService
{
    private List<UnitConfig> _unitConfigs;
    private Player _player;

    // Здесь будет логика апгрейда 
    public UpgradeService(List<UnitConfig> unitConfigs, Player player)
    {
        _unitConfigs = unitConfigs;
        _player = player;
    }

    public void Upgrade()
    {
        var player = Object.Instantiate(_unitConfigs[1].UnitPrefab, _player.transform.position, _player.transform.rotation);
        Object.Destroy(_player.gameObject);
        _player = player.GetComponent<Player>();
        _player.Init(_unitConfigs[1].GetStats());
    }
}
