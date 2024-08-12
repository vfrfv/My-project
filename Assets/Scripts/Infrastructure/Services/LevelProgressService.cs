using System;

public class LevelProgressService
{
    private int _killedOpponents = 0;
    private int _numberFragsUpgrade = 4;
    private UpgradeService _upgradeService;

    public LevelProgressService(UpgradeService upgradeService)
    {
        _upgradeService = upgradeService;
    }

    public int KilledOpponents => _killedOpponents;
    public int NumberFragsUpgrade => _numberFragsUpgrade;

    public event Action Improved;
    public event Action MovedNextLevel;
    public event Action<int> Changed;

    public void AddProgress(Enemy enemy)
    {
        _killedOpponents++;

        if (_killedOpponents >= _numberFragsUpgrade)
        {
            Improved?.Invoke();
            _killedOpponents = 0;
        }

        if (_upgradeService.IsMaxLevel())
        {
            Changed?.Invoke(_numberFragsUpgrade);      
        }
        else
        {
            Changed?.Invoke(_killedOpponents);
        }
    }
}
