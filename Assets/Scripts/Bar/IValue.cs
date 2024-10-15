using System;

namespace Assets.Scripts.Bar
{
    public interface IValue
    {
        event Action<int> Changed;

        int Value { get; }
        int MaxValue { get; }
    }
}