using System.Text;
using Sample.System;
using UnityEngine;

namespace UI.PlayerList
{
    public sealed class PlayerListViewAdapter : MonoBehaviour
    {
        [SerializeField]
        private PlayerListStorage _playerListStorage;
        
        [SerializeField]
        private PlayerListView _playerListView;

        private readonly StringBuilder _stringBuilder = new();
        
        private void OnEnable()
        {
            _playerListStorage.OnPlayerListChanged += DisplayPlayerList;
        }

        private void OnDisable()
        {
            _playerListStorage.OnPlayerListChanged -= DisplayPlayerList;
        }

        private void DisplayPlayerList()
        {
            _stringBuilder.Clear();
            
            foreach (string playerName in _playerListStorage.GetNames())
            {
                _stringBuilder.Append(playerName);
                _stringBuilder.AppendLine();
            }
            
            string playerList = _stringBuilder.ToString();
            _playerListView.SetPlayerList(playerList);
        }
    }
}