using AssemblyCSharp.Assets.Scripts.Interfaces;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Damage
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private bool _destroyOnDamage = true;
        [SerializeField] private string _damagingObjectTag;
        public bool IsDestroying() => _destroyOnDamage;
        public void DamageEntity(GameObject entity)
        {
            if (entity.CompareTag(_damagingObjectTag) && entity.TryGetComponent(out Health.Health health))
            {
                health.TakeDamage(_damage);
                if (_destroyOnDamage)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
