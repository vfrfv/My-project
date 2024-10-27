using Tanks;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Unit Config", menuName = "Tank/Create new unit config")]
    public class UnitConfig : ScriptableObject
    {
        [SerializeField] private TankModel _tankModelPrefab;
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField] private float _shootDelayInSeconds;

        public TankModel TankModel => _tankModelPrefab;
        public int Health => _health;
        public int Damage => _damage;
        public float ShootDelayInSeconds => _shootDelayInSeconds;
    }
}