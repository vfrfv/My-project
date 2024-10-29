using UnityEngine;

namespace Tanks
{
    public class EffectsController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _prefabExplosionEffect;
        [SerializeField] protected ParticleSystem _prefabShootEffect;

        private int _timerDestroyingDeathEffect = 2;
        private int _timerDestroyingEffectShot = 1;

        public void ReproduceTankExplosion()
        {
            ParticleSystem explosionEffect = Instantiate(_prefabExplosionEffect, transform.position, Quaternion.identity);
            Destroy(explosionEffect.gameObject, _timerDestroyingDeathEffect);
        }

        public void PlayShootEffect(Transform shootPoint)
        {
            ParticleSystem shootEffect = Instantiate(_prefabShootEffect, shootPoint.position, shootPoint.rotation);
            Destroy(shootEffect.gameObject, _timerDestroyingEffectShot);
        }
    }
}