using System.Collections.Generic;
using Fusion;
using UnityEngine;

namespace Sample.System
{
    public sealed class PlayerListStorageController : NetworkBehaviour
    {
        [SerializeField]
        private PlayerListStorage _playerListStorage;
        
        [SerializeField]
        private PlayerSpawner _playerSpawner;

        [SerializeField]
        private PlayerDespawner _playerDespawner;
        
        public override void Spawned()
        {
            if (!Runner.IsServer) return;
            
            _playerSpawner.OnPlayerSpawned += OnPlayerSpawned;
            _playerDespawner.OnPlayerDespawned += OnPlayerDespawned;
            
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            if (!Runner.IsServer) return;
            
            _playerSpawner.OnPlayerSpawned -= OnPlayerSpawned;
            _playerDespawner.OnPlayerDespawned -= OnPlayerDespawned;
        }
        
        private void OnPlayerSpawned(PlayerRef playerRef, NetworkObject playerObject)
        {
            _playerListStorage.AddName(playerRef, playerObject.name);
        }
        
        private void OnPlayerDespawned(PlayerRef playerRef)
        {
            _playerListStorage.RemoveName(playerRef);
        }
    }
}