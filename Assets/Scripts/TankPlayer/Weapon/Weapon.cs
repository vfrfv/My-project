using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Missile _prefabMissile;

    private float _shootDelayCounter = 0;
    private readonly float _shootDelayInSeconds = 1;

    public bool CanShoot => _shootDelayCounter <= 0;

    public void Shoot()
    {
        if (CanShoot == false)
        {
            return;
        }

        _shootDelayCounter = _shootDelayInSeconds;
        Missile missile = Instantiate(_prefabMissile, transform.position, transform.rotation);
        StartCoroutine(StartCooldown());
    }

    private IEnumerator StartCooldown()
    {
        float step = 0.01f;
        var wait = new WaitForSeconds(step);

        while (CanShoot == false)
        {
            _shootDelayCounter -= step;

            yield return wait;
        }
    }
}
