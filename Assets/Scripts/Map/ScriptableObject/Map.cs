using UnityEngine;

[CreateAssetMenu(fileName = "New Map", menuName = "Map/New Map")]
public class Map : ScriptableObject
{
    [SerializeField] private int _mapIndex;
    [SerializeField] private string _mapName;
    [SerializeField] private Sprite _mapImage;
    [SerializeField] private string _nameScene;

    public int MapIndex => _mapIndex;
    public string MapName => _mapName;
    public Sprite MapImage => _mapImage;
    public string NameScene => _nameScene;
}
