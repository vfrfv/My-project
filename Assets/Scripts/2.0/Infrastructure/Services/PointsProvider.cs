using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsProvider 
{
    private FlightTower _flightTower;
    private IValue _value;

    public PointsProvider(FlightTower flightTower, IValue value)
    {
        _flightTower = flightTower ?? throw new ArgumentNullException(nameof(flightTower));
        _value = value ?? throw new ArgumentNullException(nameof(value));
    }


}
