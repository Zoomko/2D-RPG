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
        private readonly CoroutineRunner _coroutineRunner
            ;
        private IStaticDataService _staticDataService;
        private Dictionary<EnemyType, Pool> _enemies;

        public EnemyFactory(IStaticDataService staticDataService, IPlayerFactory playerFactory,CoroutineRunner coroutineRunner)
        {
            _staticDataService = staticDataService;
            _playerFactory = playerFactory;
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

            var enemyStateMachine = enemyGameObject.GetComponent<EnemyStateMachine>();
            var attackController = enemyGameObject.GetComponent<EnemyAttackController>();
            var movementController = enemyGameObject.GetComponent<EnemyMovementController>();
            var healthController = enemyGameObject.GetComponent<EnemyHealthController>();
            var dieController = enemyGameObject.GetComponent<EnemyDieController>();
            var characteristics = _staticDataService.Enemies.Collection[enemyType].EnemyCharacteristics;

            healthController.Contructor(characteristics);
            movementController.Contructor(characteristics);
            attackController.Contructor(characteristics);
            enemyStateMachine.Contructor(_coroutineRunner, characteristics, _playerFactory.Player.transform, attackController, movementController);

            return enemyGameObject;
        }
    }
}
