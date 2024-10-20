using Assets.Scripts.Infrastructure.Zones;
using Assets.Scripts.Tanks.TankEnemy.Tank;
using System;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class ZoneService
    {
        private List<Zone> _zones = new List<Zone>();

        public ZoneService(List<Zone> zones)
        {
            _zones = zones ?? throw new ArgumentNullException(nameof(zones));
        }

        public List<Enemy> GetAllEnemies()
        {
            List<Enemy> enemys = new List<Enemy>();

            foreach (Zone zone in _zones)
            {
                foreach (Enemy enemy in zone.Enemies)
                {
                    enemys.Add(enemy);
                }
            }

            return enemys;
        }
    }
}