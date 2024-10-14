using UnityEngine;

[CreateAssetMenu(fileName = "Unit Config", menuName = "Tank/Create new unit config")]
public class UnitConfig : ScriptableObject
{
    [SerializeField] private TankModel _TankModelPrefab;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _shootDelayInSeconds;

    public TankModel TankModel => _TankModelPrefab;
    public int Health => _health;
    public int Damage => _damage;
    public float ShootDelayInSeconds => _shootDelayInSeconds;
}
