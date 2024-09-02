using UnityEngine;

namespace Sample.Entities
{
    //View
    public sealed class DeathRenderComponent : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer _meshRenderer;

        [SerializeField]
        private DeathComponent _deathComponent;

        private void OnEnable()
        {
            _deathComponent.OnDeath += this.OnDeath;
        }

        private void OnDisable()
        {
            _deathComponent.OnDeath -= this.OnDeath;
        }

        private void OnDeath()
        {
            _meshRenderer.enabled = false;
        }
    }
}