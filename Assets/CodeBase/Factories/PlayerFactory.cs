using Assets.CodeBase.App.Services.Input;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Inventory;
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
        private readonly InventoryController _inventoryController;
        private readonly ILootFactory _lootFactory;
        private readonly IStaticDataService _staticDataService;

        private GameObject _player;

        public GameObject Player => _player;
        public PlayerFactory(IStaticDataService staticDataService,
                             IInputService inputService,
                             IBulletFactory bulletFactory,
                             InventoryController inventoryController,
                             ILootFactory lootFactory)
        {
            _staticDataService = staticDataService;
            _inputService = inputService;
            _bulletFactory = bulletFactory;
            _inventoryController = inventoryController;
            _lootFactory = lootFactory;
        }
        public GameObject Create()
        {
            var playerPrefab = _staticDataService.Player.Prefab;
            var playerGameObject = GameObject.Instantiate(playerPrefab);

            var movementController = playerGameObject.GetComponent<PlayerMovementController>();
            var healthController = playerGameObject.GetComponent<PlayerHealthController>();
            var dieController = playerGameObject.GetComponent<PlayerDieController>();
            var attackController = playerGameObject.GetComponent<PlayerAttackController>();
            var lootGrabber = playerGameObject.GetComponent<LootGrabber>();
            var characteristics = _staticDataService.Player.PlayerCharacteristics;

            healthController.Contructor(characteristics);
            movementController.Contructor(characteristics, _inputService);
            attackController.Contructor(characteristics, _inputService, _bulletFactory, _inventoryController);
            lootGrabber.Constructor(_inventoryController, _staticDataService.Player, _lootFactory);
            _player = playerGameObject;
            return _player;
        }
    }
}
