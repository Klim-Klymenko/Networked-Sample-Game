using UnityEngine;

namespace Sample.Entities
{
    [RequireComponent(typeof(StateMachine))]
    public sealed class CommandComponent : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private DealDamageComponent _dealDamageComponent;

        private void Awake()
        {
            _stateMachine = this.GetComponent<StateMachine>();
            _dealDamageComponent = this.GetComponent<DealDamageComponent>();
        }

        public void Move(Vector3 position)
        {
            _stateMachine.ChangeState(new MoveState(position));
        }

        public void Follow(Transform target)
        {
            _stateMachine.ChangeState(new FollowState(target));
        }

        public void Patrol(Vector3 position)
        {
            _stateMachine.ChangeState(new PatrolState(position, this.transform.position));
        }

        //Host
        public void Attack(GameObject target)
        {
            _dealDamageComponent.DealDamage(target);
        }

        public void Stop()
        {
            _stateMachine.DropState();
        }
    }
}