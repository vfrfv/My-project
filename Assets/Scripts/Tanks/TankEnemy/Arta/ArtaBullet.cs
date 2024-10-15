using UnityEngine;

namespace Assets.Scripts.Tanks.TankEnemy.Arta
{
    public class ArtaBullet : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other != null)
            {
                Destroy(gameObject);
            }
        }
    }
}