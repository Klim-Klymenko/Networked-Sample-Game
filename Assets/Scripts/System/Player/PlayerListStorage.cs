using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Fusion;

namespace Sample.System
{
    public sealed class PlayerListStorage : NetworkBehaviour
    {
        public event Action OnPlayerListChanged; 

        [Networked]
        [Capacity(10)]
        [OnChangedRender(nameof(OnPlayerListChangedHandler))]
        [UnitySerializeField]
        private NetworkDictionary<PlayerRef, NetworkString<_16>> Names { get; }

        public override void Spawned()
        {
            OnPlayerListChanged?.Invoke();
        }

        public void AddName(PlayerRef player, string playerName)
        {
            Names.Add(player, playerName);
        }
        
        public void RemoveName(PlayerRef player)
        {
            Names.Remove(player);
        }

        public IEnumerable<string> GetNames()
        {
            if (!StateBufferIsValid)
                yield break;
            
            foreach (KeyValuePair<PlayerRef, NetworkString<_16>> pair in Names)
            {
                yield return pair.Value.ToString();
            }
        }
        
        private void OnPlayerListChangedHandler()
        {
            OnPlayerListChanged?.Invoke();
        }
    }
}