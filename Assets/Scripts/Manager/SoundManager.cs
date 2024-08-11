using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _soundBackground;
    [SerializeField] private AudioSource _soundBossBackground;

    private void Start()
    {
        _soundBackground.Play();
        _soundBossBackground.Stop();
    }

    public void TurnOnBossBattle()
    {
        _soundBackground.Stop();
        _soundBossBackground.Play();
    }
}
