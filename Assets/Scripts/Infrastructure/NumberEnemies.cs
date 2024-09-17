using TMPro;
using UnityEngine;

public class NumberEnemies : MonoBehaviour
{
    [SerializeField] private Zone _zone;
    [SerializeField] private TMP_Text _textMeshPro;

    private void Awake()
    {
        _zone.NumberEnemiesHasChanged += ShowNumberEnemies;
    }

    private void ShowNumberEnemies()
    {
        _textMeshPro.text = $"{_zone.Enemies.Count}";
    }
}
