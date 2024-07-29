using TMPro;
using UnityEngine;

public class ImageVictory : MonoBehaviour
{
    [SerializeField] private TMP_Text _textPoints;
    [SerializeField] private FlightTower _flightTower;

    private void Start()
    {
        _flightTower.NumberPointsChanged += ShowPoints;
    }

    private void ShowPoints(float point)
    {
        _textPoints.text = $"Начислено {point.ToString("F0")} очков";
    }
}
