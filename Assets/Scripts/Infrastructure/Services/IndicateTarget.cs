using Assets.Scripts.Bar;
using Assets.Scripts.Tanks.TankPlayer;
using Cinemachine;
using System;

namespace Assets.Scripts.Infrastructure.Services
{
    public class IndicateTarget
    {
        private CinemachineVirtualCamera _camera;
        private readonly SmoothBar _smoothHealthBar;

        public IndicateTarget(CinemachineVirtualCamera camera, SmoothBar smoothHealthBar)
        {
            _camera = camera ?? throw new ArgumentNullException(nameof(camera));

            _smoothHealthBar = smoothHealthBar ?? throw new ArgumentNullException(nameof(smoothHealthBar));
        }

        public void BindPlayerToCamera(Player player)
        {
            _camera.Follow = player.transform;
            _camera.LookAt = player.transform;
        }

        public void BindPlayerToHealthBar(Player player)
        {
            _smoothHealthBar.Init(player);
        }
    }
}