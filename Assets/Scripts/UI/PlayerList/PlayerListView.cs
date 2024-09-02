using UnityEngine;
using UnityEngine.UI;

namespace UI.PlayerList
{
    public sealed class PlayerListView : MonoBehaviour
    {
        [SerializeField]
        private Text _playerListText;
        
        public void SetPlayerList(string playerList)
        {
            _playerListText.text = playerList;
        }
    }
}