using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicateTarget 
{
    private CinemachineVirtualCamera _camera;
    private ArtaAttack _artaAttack;
    private SmoothHealthBar _smoothHealthBar;

    public IndicateTarget(CinemachineVirtualCamera camera,  ArtaAttack artaAttack, SmoothHealthBar smoothHealthBar)
    {
        _camera = camera ?? throw new ArgumentNullException(nameof(camera));
        _artaAttack = artaAttack ?? throw new ArgumentNullException(nameof(artaAttack));
        _smoothHealthBar = smoothHealthBar ?? throw new ArgumentNullException(nameof(smoothHealthBar));
    }

    public void BindPlayerToCamera (Player player)
    {
        _camera.Follow = player.transform;
        _camera.LookAt = player.transform;
    }

    public void BindPlayerToArta(Player player)
    {
        _artaAttack.GetNewTarget(player);
    }

    public void BindPlayerToHealthBar(Player player)
    {
        _smoothHealthBar.Init(player);
    }
}
