using UnityEngine;

[CreateAssetMenu(fileName = "New Map", menuName = "Map/New Map")]
public class Map : ScriptableObject
{
    [SerializeField] private int _mapIndex;

    [SerializeField] private string _mapNameRU;
    [SerializeField] private string _mapNameEU;
    [SerializeField] private string _mapNameTR;


    [SerializeField] private Sprite _mapImage;
    [SerializeField] private string _nameScene;

    public int MapIndex => _mapIndex;
    public string MapNameRU => _mapNameRU;
    public string MapNameEU => _mapNameEU;
    public string MapNameTR => _mapNameTR;
    public Sprite MapImage => _mapImage;
    public string NameScene => _nameScene;
}
