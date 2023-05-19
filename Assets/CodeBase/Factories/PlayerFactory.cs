using Assets.CodeBase.App.Services.Input;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Player;
using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;

namespace Assets.CodeBase.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IInputService _inputService;
        private readonly IBulletFactory _bulletFactory;
        private readonly IStaticDataService _staticDataService;

        private GameObject _player;

        public GameObject Player => _player;
        public PlayerFactory(IStaticDataService staticDataService,
                             IInputService inputService,
                             IBulletFactory bulletFactory)
        {
            _staticDataService = staticDataService;
            _inputService = inputService;
            _bulletFactory = bulletFactory;
        }
        public GameObject Create()
        {
            var playerPrefab = _staticDataService.Player.Prefab;
            var playerGameObject = GameObject.Instantiate(playerPrefab);

            var movementController = playerGameObject.GetComponent<PlayerMovementController>();
            var healthController = playerGameObject.GetComponent<PlayerHealthController>();
            var dieController = playerGameObject.GetComponent<PlayerDieController>();
            var attackController = playerGameObject.GetComponent<PlayerAttackController>();
            var characteristics = _staticDataService.Player.PlayerCharacteristics;

            healthController.Contructor(characteristics);
            movementController.Contructor(characteristics, _inputService);
            attackController.Contructor(characteristics, _inputService, _bulletFactory);
            _player = playerGameObject;
            return _player;
        }
    }
}
