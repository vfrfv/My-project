using TMPro;
using UnityEngine;

public class ScoringPoints : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private FlightTower _flightTower;

    private float _points = 0;
    private Coroutine _coroutine;
    private bool _works = true;

    public float Points => _points;
    public Coroutine Coroutine => _coroutine;
    public bool Works => _works;

    private void Start()
    {
        _flightTower.Flew += StartAddPoints;
        _flightTower.NumberPointsChanged += ChengPointsValue;
        _text.enabled = false;
    }

    private void OnDestroy()
    {
        _flightTower.Flew -= StartAddPoints;
        _flightTower.NumberPointsChanged -= ChengPointsValue;
    }

    private void StartAddPoints()
    {
        _text.enabled = true;
    }

    private void ChengPointsValue(float value)
    {
        _text.text = value.ToString("F0");
    }
}