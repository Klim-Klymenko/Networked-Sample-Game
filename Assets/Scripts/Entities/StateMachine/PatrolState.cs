using UnityEngine;

namespace Sample.Entities
{
    public sealed class PatrolState : IState
    {
        private readonly Vector3[] waypoints;
        private int index;
        
        public PatrolState(params Vector3[] waypoints)
        {
            this.waypoints = waypoints;
            this.index = 0;
        }

        public void Enter(GameObject entity)
        {
        }

        public void Update(GameObject entity, float deltaTime)
        {
            Vector3 currentPosition = entity.transform.position;
            Vector3 targetPosition = this.waypoints[this.index];
            Vector3 distanceVector = targetPosition - currentPosition;
            
            StoppingDistanceComponent distanceComponent = entity.GetComponent<StoppingDistanceComponent>();

            if (distanceVector.sqrMagnitude <= distanceComponent.DistanceSqr)
            {
                this.index = (this.index + 1) % this.waypoints.Length;
                return;
            }

            Vector3 moveDirection = distanceVector.normalized;
            entity.GetComponent<MovementComponent>().Move(moveDirection, deltaTime);
        }

        public void Exit(GameObject entity)
        {
        }
    }
}