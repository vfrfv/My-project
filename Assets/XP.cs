using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XP : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _button.onClick.AddListener(Xp);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Xp);
    }

    private void Xp()
    {
        _player.XP();
    }
}
