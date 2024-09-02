using UnityEngine;

namespace Sample.Entities
{
    public sealed class StoppingDistanceComponent : MonoBehaviour
    {
        public float DistanceSqr
        {
            get { return this.stoppingDistance * this.stoppingDistance; }
        }

        [SerializeField]
        private float stoppingDistance;
    }
}