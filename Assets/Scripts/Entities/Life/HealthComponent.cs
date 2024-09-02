using Fusion;
using UnityEngine;

namespace Sample.Entities
{
    public sealed class HealthComponent : NetworkBehaviour
    {
        [Networked] //Host->Client
        public int Health { get; set; }

        [SerializeField]
        private int maxHealth = 10;

        public override void Spawned() => this.Health = this.maxHealth;

        public void TakeDamage(int damage)
        {
            if (this.Health <= 0)
                return;

            this.Health = Mathf.Max(0, Health - damage);
            Debug.Log($"Take Damage {damage}");

            if (this.Health <= 0)
            {
                Debug.Log("Death");
                this.gameObject.GetComponent<DeathComponent>().Death();
            }
        }
    }
}