using System;
using Fusion;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sample.System
{
    public sealed class PlayerSpawner : SimulationBehaviour
    {
        public event Action<PlayerRef, NetworkObject> OnPlayerSpawned; 
        
        [SerializeField]
        private NetworkPrefabRef _playerPrefab;

        [SerializeField]
        private Bounds _spawnArea; 
        
        public void SpawnPlayer(PlayerRef playerRef)
        {
            Vector3 spawnPoint = RandomSpawnPoint();
            NetworkObject playerObject = Runner.Spawn(_playerPrefab, spawnPoint, Quaternion.identity, playerRef);
            
            Runner.SetPlayerObject(playerRef, playerObject);
            OnPlayerSpawned?.Invoke(playerRef, playerObject);
        }

        private Vector3 RandomSpawnPoint()
        {
            return new Vector3(Random.Range(_spawnArea.min.x, _spawnArea.max.x), 0, Random.Range(_spawnArea.min.z, _spawnArea.max.z));
        }
    }
}