using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZoneService 
{
    //private int _killedOpponents;
    //private int _numberFragmentsMoveSecondZone = 5;

    //public event Action MovedNextZone;

    //public void AddProgress(Enemy enemy)
    //{
    //    _killedOpponents++;

    //    if (_killedOpponents >= _numberFragmentsMoveSecondZone)
    //    {
    //        MovedNextZone?.Invoke();
    //        _killedOpponents = 0;
    //    }
    //}

    private List<Zone> _zones = new List<Zone>();

    public ZoneService(List<Zone> zones)
    {
        _zones = zones ?? throw new ArgumentNullException(nameof(zones));
    }

    public List<Enemy> GetAllEnemies()
    {
        List<Enemy> enemys = new List<Enemy>();

        foreach (Zone zone in _zones)
        {
            foreach(Enemy enemy in zone.Enemies)
            {
                enemys.Add(enemy);
            }
        }
        Debug.Log($"Врагов во всех зонах {enemys.Count}");

        return enemys;
    }
}
