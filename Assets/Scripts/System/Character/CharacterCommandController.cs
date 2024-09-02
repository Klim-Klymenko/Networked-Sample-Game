using Sample.Entities;
using UnityEngine;

namespace Sample.System
{
    //Вызывает команды у игрока
    public sealed class CharacterCommandController : MonoBehaviour
    {
        private ClickInput _clickInput;
        private CharacterProvider _characterProvider;

        private void Awake()
        {
            _clickInput = this.GetComponent<ClickInput>();
            _characterProvider = this.GetComponent<CharacterProvider>();
        }
        
        private void OnEnable()
        {
            _clickInput.OnPointClicked += this.OnPointClicked;
            _clickInput.OnTargetClicked += this.OnTargetClicked;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                _characterProvider.Character.GetComponent<CommandProvider>().Stop();
            }
        }

        private void OnDisable()
        {
            _clickInput.OnPointClicked -= this.OnPointClicked;
            _clickInput.OnTargetClicked -= this.OnTargetClicked;
        }

        private void OnPointClicked(Vector3 point)
        {
            if (Input.GetKey(KeyCode.M))
            {
                GameObject character = _characterProvider.Character;
                character.GetComponent<CommandProvider>().Move(point);
                return;
            }

            if (Input.GetKey(KeyCode.P))
            {
                GameObject character = _characterProvider.Character;
                character.GetComponent<CommandProvider>().Patrol(point);
            }
        }

        private void OnTargetClicked(GameObject target)
        {
            if (target == _characterProvider.Character)
            {
                return;
            }

            if (Input.GetKey(KeyCode.F))
            {
                _characterProvider.Character.GetComponent<CommandProvider>().Follow(target.transform);
            }

            if (Input.GetKey(KeyCode.A))
            {
                _characterProvider.Character.GetComponent<CommandProvider>().Attack(target);
            }
        }
    }
}