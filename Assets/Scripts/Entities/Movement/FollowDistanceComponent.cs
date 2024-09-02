using UnityEngine;

namespace Sample.Entities
{
    public sealed class FollowDistanceComponent : MonoBehaviour
    {
        public float DistanceSqr
        {
            get { return this.distance * this.distance; }
        }

        [SerializeField]
        private float distance;
    }
}