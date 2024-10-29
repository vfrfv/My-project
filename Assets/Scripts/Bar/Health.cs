using System;
using UnityEngine;

namespace Bar
{
    public class Health : MonoBehaviour, IValue
    {
        public int Value => throw new NotImplementedException();

        public int MaxValue => throw new NotImplementedException();

        public event Action<int> Changed;
    }
}