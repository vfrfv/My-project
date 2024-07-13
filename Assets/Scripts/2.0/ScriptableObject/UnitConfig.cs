using UnityEngine;

[CreateAssetMenu(fileName = "Unit Config", menuName = "Tank/Create new unit config")]
public class UnitConfig : ScriptableObject
{
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _shootDelayInSeconds;
    [SerializeField] private float _fieldView;

    public GameObject UnitPrefab => _unitPrefab;

    public StatsDto GetStats()
    {
        return new StatsDto()
        {
            Health = _health,
            Damage = _damage,
            ShootDelayInSeconds = _shootDelayInSeconds,
            FieldView = _fieldView
        };
    }
}

public struct StatsDto
{
    public int Health;
    public int Damage;
    public float ShootDelayInSeconds;
    public float FieldView;
}
