using Assets.CodeBase.Data.StaticData.Enemy;
using Assets.CodeBase.Factories;
using Assets.CodeBase.Services;
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

        public CreateObjectsState(GameStateMachine gameStateMachine,
                                  PersistentDataService persistentDataService,
                                  IPlayerFactory playerFactory,
                                  IEnemyFactory enemyFactory,
                                  IHUDFactory hudFactory,
                                  IBulletFactory bulletFactory)
        {
            _gameStateMachine = gameStateMachine;
            _persistentDataService = persistentDataService;
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            _hudFactory = hudFactory;
            _bulletFactory = bulletFactory;
        }
        public void Enter()
        {
            _persistentDataService.Load();
            if (_persistentDataService.IsDataEmpty)
            {
                var playerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();
                var enemySpanwers = GameObject.FindObjectsOfType<EnemySpanwer>();

                var player = _playerFactory.Create();
                playerSpawner.Spawn(player);

                _enemyFactory.InitializePool();
                _bulletFactory.InitializePool();

                for (int i = 0; i < enemySpanwers.Length; i++)
                {
                    var enemy = _enemyFactory.Create(EnemyType.Zombie);
                    enemySpanwers[i].Spawn(enemy);
                }
            }
            _hudFactory.Create();
        }

        public void Exit()
        {
        }
    }
}
