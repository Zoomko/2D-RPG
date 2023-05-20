using Assets.CodeBase.App.Services;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Data.StaticData.Enemy;
using Assets.CodeBase.Enemy;
using Assets.CodeBase.Enemy.StateMachine;
using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly ILootFactory _lootFactory;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly IStaticDataService _staticDataService;

        private Dictionary<EnemyType, Pool> _enemies;

        public EnemyFactory(IStaticDataService staticDataService, IPlayerFactory playerFactory, ILootFactory lootFactory, CoroutineRunner coroutineRunner)
        {
            _staticDataService = staticDataService;
            _playerFactory = playerFactory;
            _lootFactory = lootFactory;
            _coroutineRunner = coroutineRunner;
        }

        public void InitializePool()
        {
            _enemies = new Dictionary<EnemyType, Pool>();
            foreach(var enemy in _staticDataService.Enemies.Collection)
            {
                _enemies.Add(enemy.Key, new Pool(enemy.Value.EnemyPrefab));
            }
        }

        public GameObject Create(EnemyType enemyType)
        {
            var enemyGameObject = _enemies[enemyType].Get();
            var enemyInfo = enemyGameObject.GetComponent<Enemy.EnemyInfo>();

            if (!enemyInfo.IsInitialized)
            {
                InitializeEnemy(enemyType, enemyGameObject,enemyInfo);
            }
            else
            {
                enemyGameObject.SetActive(true);
                var enemyStateMachine = enemyGameObject.GetComponent<EnemyStateMachine>();
                enemyStateMachine.Enter<DetectState>();
            }

            return enemyGameObject;
        }

        private void InitializeEnemy(EnemyType enemyType, GameObject enemyGameObject, Enemy.EnemyInfo enemyInfo)
        {
            var dieController = enemyGameObject.GetComponent<EnemyDieController>();
            var enemyStateMachine = enemyGameObject.GetComponent<EnemyStateMachine>();
            var attackController = enemyGameObject.GetComponent<EnemyAttackController>();
            var movementController = enemyGameObject.GetComponent<EnemyMovementController>();
            var healthController = enemyGameObject.GetComponent<EnemyHealthController>();
            var characteristics = _staticDataService.Enemies.Collection[enemyType].EnemyCharacteristics;

            healthController.Contructor(characteristics);
            movementController.Contructor(characteristics);
            attackController.Contructor(characteristics);
            enemyStateMachine.Contructor(_coroutineRunner, characteristics, _playerFactory.Player.transform, attackController, movementController);
            dieController.Constructor(_lootFactory, _staticDataService.Enemies.Collection[enemyType].Loot);
            dieController.Died += OnEnemyDied;

            enemyInfo.IsInitialized = true;
        }

        private void OnEnemyDied(GameObject enemyGameObject) 
        {
            var enemyStateMachine = enemyGameObject.GetComponent<EnemyStateMachine>();
            var enemyInfo = enemyGameObject.GetComponent<Enemy.EnemyInfo>();
            enemyStateMachine.Enter<DoNothingState>();
            enemyGameObject.SetActive(false);
            _enemies[enemyInfo.Type].Put(enemyGameObject);
        }
    }
}
