using UnityEngine;

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