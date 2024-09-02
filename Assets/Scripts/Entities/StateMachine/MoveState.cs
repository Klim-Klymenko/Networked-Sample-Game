using UnityEngine;

namespace Sample.Entities
{
    public sealed class MoveState : IState
    {
        private readonly Vector3 targetPosition;

        public MoveState(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
        }

        public void Enter(GameObject entity)
        {
        }

        public void Update(GameObject entity, float deltaTime)
        {
            Vector3 currentPosition = entity.transform.position;
            Vector3 distanceVector = this.targetPosition - currentPosition;
            distanceVector.y = 0;

            StoppingDistanceComponent distanceComponent = entity.GetComponent<StoppingDistanceComponent>();
            if (distanceVector.sqrMagnitude <= distanceComponent.DistanceSqr)
            {
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