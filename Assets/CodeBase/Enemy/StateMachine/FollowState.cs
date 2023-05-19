using Assets.CodeBase.App.Services;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Enemy.StateMachine;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    public class FollowState : IEnemyState
    {
        private readonly EnemyStateMachine _enemyStateMachine;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly EnemyCharacteristics _enemyCharacteristics;
        private readonly EnemyMovementController _enemyMovementController;
        private readonly Transform _playerTransform;
        private readonly Transform _thisTransform;

        private Coroutine _coroutine;

        public FollowState(EnemyStateMachine enemyStateMachine,
                           CoroutineRunner coroutineRunner,
                           EnemyCharacteristics enemyCharacteristics,
                           EnemyMovementController enemyMovementController,
                           Transform playerTransform,
                           Transform thisTransform)
        {
            _enemyStateMachine = enemyStateMachine;
            _coroutineRunner = coroutineRunner;
            _enemyCharacteristics = enemyCharacteristics;
            _enemyMovementController = enemyMovementController;
            _playerTransform = playerTransform;
            _thisTransform = thisTransform;
        }

        public void Enter()
        {
            _coroutine = _coroutineRunner.StartCoroutine(Following());
        }

        public void Exit()
        {
            if (_coroutine != null)
                _coroutineRunner.StopCoroutine(_coroutine);
        }

        private IEnumerator Following()
        {
            while (DistanceToPlayer() > _enemyCharacteristics.RadiusOfAttack
                  && DistanceToPlayer() < _enemyCharacteristics.RadiusOfDetection)
            {
                var vectorTowardsToPlayer = ( _playerTransform.position - _thisTransform.position ).normalized;
                _enemyMovementController.Move(vectorTowardsToPlayer);
                yield return null;
            }
            if (DistanceToPlayer() < _enemyCharacteristics.RadiusOfAttack)
                _enemyStateMachine.Enter<AttackState>();
            if (DistanceToPlayer() > _enemyCharacteristics.RadiusOfDetection)
                _enemyStateMachine.Enter<DetectState>();
        }

        private float DistanceToPlayer()
        {
            return Vector3.Distance(_playerTransform.position, _thisTransform.position);
        }
    }
}
