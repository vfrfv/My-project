using UnityEngine;

public class PlayerPoolHandler : MonoBehaviour
{
    [SerializeField] private Missile _prefabMissile;

    private PlayerPoolMissile _pool;

    public PlayerPoolMissile Pool => _pool;

    private void Awake()
    {
        _pool = new PlayerPoolMissile(_prefabMissile);
    }
}
