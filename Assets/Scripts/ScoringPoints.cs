using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoringPoints : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private FlightTower _flightTower;

    private float _glasses = 0;
    private Coroutine _coroutine;

    private void Start()
    {
        _flightTower.Flew += StartAddPoints;
        _text.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Earth earth))
        {
            StopCoroutine(_coroutine);

            _flightTower.Flew -= StartAddPoints;
        }
    }

    private void StartAddPoints()
    {
        _text.enabled = true;

        _coroutine = StartCoroutine(AddPoints());
    }

    private IEnumerator AddPoints()
    {
        bool works = true;

        while (works)
        {
            _glasses += Time.deltaTime;

            //_text.text = Convert.ToInt32(_glasses).ToString();
            _text.text = Convert.ToInt32(_glasses * 100).ToString();

            yield return null;
        }
    }
}
