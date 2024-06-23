using System;

public interface IHealth
{
    event Action<int> Changed;

    int Value { get; }
}