using Assets.CodeBase.App.Services.Input;
using Assets.CodeBase.Data.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private PlayerCharacteristics _playerCharacteristics;
        private IInputService _inputService;
        public void Contructor(PlayerCharacteristics playerCharacteristics, IInputService inputService)
        {
            _playerCharacteristics = playerCharacteristics;
            _inputService = inputService;
        }
        private void Update()
        {
            Move();
        }
        private void Move()
        {
            transform.Translate(_inputService.MoveVector * _playerCharacteristics.MovementSpeed * Time.deltaTime);
        }
    }
}
