using System;
using Fusion;

namespace Sample.System
{
    public sealed class PlayerDespawner : SimulationBehaviour
    {
        public event Action<PlayerRef> OnPlayerDespawned; 
        
        public void DespawnPlayer(PlayerRef playerRef)
        {
            NetworkObject playerObject = Runner.GetPlayerObject(playerRef);
            
            if (playerObject == null)
                return;

            Runner.SetPlayerObject(playerRef, null);
            Runner.Despawn(playerObject);
            
            OnPlayerDespawned?.Invoke(playerRef);
        }
    }
}