using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicateTarget 
{
    private CinemachineVirtualCamera _camera;
    private ArtaAttack _artaAttack;

    public IndicateTarget(CinemachineVirtualCamera camera, ArtaAttack artaAttack)
    {
        _camera = camera ?? throw new ArgumentNullException(nameof(camera));
        _artaAttack = artaAttack ?? throw new ArgumentNullException(nameof(artaAttack));
    }

    public void InstallNewPlayerCamera (Player player)
    {
        _camera.Follow = player.transform;
        _camera.LookAt = player.transform;
    }

    public void InstallNewPlayerArta(Player player)
    {
        _artaAttack.GetNewTarget(player);
    }
}
