using UnityEngine;

namespace Sample.Entities
{
    public sealed class FollowState : IState
    {
        private readonly Transform target;
        
        public FollowState(Transform target)
        {
            this.target = target;
        }

        public void Enter(GameObject entity)
        {
        }

        public void Update(GameObject entity, float deltaTime)
        {
            Vector3 currentPosition = entity.transform.position;
            Vector3 distanceVector = this.target.position - currentPosition;
            float distanceSqr = entity.GetComponent<FollowDistanceComponent>().DistanceSqr;

            if (distanceVector.sqrMagnitude <= distanceSqr)
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