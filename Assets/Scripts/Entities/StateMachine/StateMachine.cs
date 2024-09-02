using Fusion;

namespace Sample.Entities
{
    public sealed class StateMachine : NetworkBehaviour
    {
        private IState _currentState;

        public void ChangeState(IState state)
        {
            _currentState?.Exit(this.gameObject);
            _currentState = state;
            _currentState?.Enter(this.gameObject);
        }

        public void DropState()
        {
            _currentState?.Exit(this.gameObject);
            _currentState = null;
        }

        public override void FixedUpdateNetwork()
        {
            _currentState?.Update(this.gameObject, this.Runner.DeltaTime);
        }
    }
}