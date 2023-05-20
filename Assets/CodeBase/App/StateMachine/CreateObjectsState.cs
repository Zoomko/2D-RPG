using Assets.CodeBase.Data.StaticData.Enemy;
using Assets.CodeBase.Factories;
using Assets.CodeBase.Inventory;
using Assets.CodeBase.Services;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.App.StateMachine
{
    public class CreateObjectsState : INoneParameterizedState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly PersistentDataService _persistentDataService;
        private readonly IPlayerFactory _playerFactory;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IHUDFactory _hudFactory;
        private readonly IBulletFactory _bulletFactory;
        private readonly ILootFactory _lootFactory;
        private readonly InventoryController _inventoryController;
        private readonly IStaticDataService _staticDataService;

        public CreateObjectsState(GameStateMachine gameStateMachine,
                                  PersistentDataService persistentDataService,
                                  IPlayerFactory playerFactory,
                                  IEnemyFactory enemyFactory,
                                  IHUDFactory hudFactory,
                                  IBulletFactory bulletFactory,
                                  ILootFactory lootFactory,
                                  InventoryController inventoryController,
                                  IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _persistentDataService = persistentDataService;
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            _hudFactory = hudFactory;
            _bulletFactory = bulletFactory;
            _lootFactory = lootFactory;
            _inventoryController = inventoryController;
            _staticDataService = staticDataService;
        }
        public void Enter()
        {
            _persistentDataService.Load();
            if (_persistentDataService.IsDataEmpty)
            {
                NewGame();
            }
            _hudFactory.Create();
        }

        private void NewGame()
        {
            var playerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();
            var enemySpanwers = GameObject.FindObjectsOfType<EnemySpanwer>();

            var player = _playerFactory.Create();
            playerSpawner.Spawn(player);

            _enemyFactory.InitializePool();
            _bulletFactory.InitializePool();
            _lootFactory.InitializePool();

            for (int i = 0; i < enemySpanwers.Length; i++)
            {
                var enemy = _enemyFactory.Create(EnemyType.Zombie);
                enemySpanwers[i].Spawn(enemy);
            }

            var _bulletId = _staticDataService.ItemsWithKeyNames["Bullet"].Id;
            _inventoryController.AddItem(_bulletId, 5);
        }

        public void Exit()
        {
        }
    }
}
