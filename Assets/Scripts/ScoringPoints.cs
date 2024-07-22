using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ScoringPoints : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private FlightTower _flightTower;

    private float _glasses = 0;
    private Coroutine _coroutine;
    private bool _works = true;

    private void Start()
    {
        _flightTower.Flew += StartAddPoints;
        _flightTower.AchievedGoal += StopAddPoints;

        _text.enabled = false;
    }

    private void StopAddPoints()
    {
        if (_coroutine != null)
        {
            _works = false;
            StopCoroutine(_coroutine);
        }

        _flightTower.Flew -= StartAddPoints;
        _flightTower.AchievedGoal -= StopAddPoints;
    }

    private void StartAddPoints()
    {
        _text.enabled = true;

        _coroutine = StartCoroutine(AddPoints());
    }

    private IEnumerator AddPoints()
    {
        while (_works)
        {
            _glasses += Time.deltaTime;
            _text.text = Convert.ToInt32(_glasses * 100).ToString();

            yield return null;
        }
    }
}
