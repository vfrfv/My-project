using System.Collections.Generic;
using UnityEngine;

public class UpgradeService
{
    private List<UnitConfig> _unitConfigs;

    // ����� ����� ������ �������� 
    public UpgradeService(List<UnitConfig> unitConfigs)
    {
        _unitConfigs = unitConfigs;
    }

    public void Upgrade()
    {
        Debug.Log("�������������");
    }
}
