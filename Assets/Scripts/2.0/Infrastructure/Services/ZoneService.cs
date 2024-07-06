using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZoneService 
{   
    private int _killedOpponents;
    private int _numberFragmentsMoveSecondZone = 5;

    public event Action MovedNextZone;

    public void AddProgress(Enemy enemy)
    {
        _killedOpponents++;

        if (_killedOpponents >= _numberFragmentsMoveSecondZone)
        {
            MovedNextZone?.Invoke();
            _killedOpponents = 0;
        }
    }
}
