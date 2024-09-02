using Fusion;
using UnityEngine;

namespace Sample.System
{
    //Предоставляет персонажа игрока
    public sealed class CharacterProvider : SimulationBehaviour
    {
        public GameObject Character
        {
            get
            {
                PlayerRef myPlayer = this.Runner.LocalPlayer;
                NetworkObject character = this.Runner.GetPlayerObject(myPlayer);
                return character.gameObject;
            }
        }
    }
}