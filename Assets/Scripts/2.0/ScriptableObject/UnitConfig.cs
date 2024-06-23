using UnityEngine;

[CreateAssetMenu(fileName = "Unit Config", menuName = "Tank/Create new unit config")]
public class UnitConfig : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    public StatsDto GetStats()
    {
        return new StatsDto()
        {
            Health = _health,
            Damage = _damage
        };
    }
}

public struct StatsDto
{
    public int Health;
    public int Damage;
}
