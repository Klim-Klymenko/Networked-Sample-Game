using System;
using Fusion;

namespace Sample.Entities
{
    public sealed class DeathComponent : NetworkBehaviour
    {
        public event Action OnDeath;

        public void Death() => this.RPC_Death();

        [Rpc(RpcSources.StateAuthority, RpcTargets.All, Channel = RpcChannel.Reliable)]
        private void RPC_Death() => this.OnDeath?.Invoke();
    }
}