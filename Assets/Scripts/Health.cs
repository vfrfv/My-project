using Bar;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IValue
{
    public int Value => throw new NotImplementedException();

    public int MaxValue => throw new NotImplementedException();

    public event Action<int> Changed;
}
