using System;

namespace Bar
{
    public interface IValue
    {
        event Action<int> Changed;

        int Value { get; }
        int MaxValue { get; }
    }
}