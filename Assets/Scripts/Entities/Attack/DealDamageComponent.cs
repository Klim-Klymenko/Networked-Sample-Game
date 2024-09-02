using UnityEngine;

namespace Sample.Entities
{
    public sealed class DealDamageComponent : MonoBehaviour
    {
        [SerializeField]
        private int damage = 1;
        
        public void DealDamage(GameObject target)
        {
            if (target.TryGetComponent(out HealthComponent healthComponent))
            {
                healthComponent.TakeDamage(this.damage);
            }
        }
    }
}