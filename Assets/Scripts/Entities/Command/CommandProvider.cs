using Fusion;
using UnityEngine;

namespace Sample.Entities
{
    [RequireComponent(typeof(CommandComponent))]
    public sealed class CommandProvider : NetworkBehaviour
    {
        private CommandComponent _commandComponent;

        private void Awake() => _commandComponent = this.GetComponent<CommandComponent>();

        public void Move(Vector3 position)
        {
            if (this.Runner.IsClient)
            {
                this.RPC_Move(position);
            }
            else
            {
                _commandComponent.Move(position);
            }
        }

        public void Follow(Transform target)
        {
            if (this.Runner.IsClient)
            {
                this.RPC_Follow(target.GetComponent<NetworkObject>());
            }
            else
            {
                _commandComponent.Follow(target);
            }
        }

        public void Patrol(Vector3 position)
        {
            if (this.Runner.IsClient)
            {
                this.RPC_Patrol(position);
            }
            else
            {
                _commandComponent.Patrol(position);
            }
        }

        public void Attack(GameObject target)
        {
            if (this.Runner.IsClient)
            {
                this.RPC_Attack(target.GetComponent<NetworkObject>());
            }
            else
            {
                _commandComponent.Attack(target);
            }
        }

        public void Stop()
        {
            if (this.Runner.IsClient)
            {
                this.RPC_Stop();
            }
            else
            {
                _commandComponent.Stop();
            }
        }

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable, InvokeLocal = false)]
        private void RPC_Move(Vector3 position) => _commandComponent.Move(position);
        
        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable, InvokeLocal = false)]
        private void RPC_Follow(NetworkObject target) => _commandComponent.Follow(target.transform);

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable, InvokeLocal = false)]
        private void RPC_Patrol(Vector3 position) => _commandComponent.Patrol(position);

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable, InvokeLocal = false)]
        private void RPC_Attack(NetworkObject target) => _commandComponent.Attack(target.gameObject);

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable, InvokeLocal = false)]
        private void RPC_Stop() => _commandComponent.Stop();
    }
}