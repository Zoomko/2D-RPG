using Assets.CodeBase.App.Services;
using Assets.CodeBase.Data.StaticData;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Enemy.StateMachine
{
    public class DetectState : IEnemyState
    {
        private readonly EnemyStateMachine _enemyStateMachine;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly EnemyCharacteristics _enemyCharacteristics;
        private readonly Transform _playerTransform;
        private readonly Transform _thisTransform;

        private Coroutine _coroutine;
        public DetectState(EnemyStateMachine enemyStateMachine,
                           CoroutineRunner coroutineRunner,
                           EnemyCharacteristics enemyCharacteristics,
                           Transform playerTransform,
                           Transform thisTransform)
        {
            _enemyStateMachine = enemyStateMachine;
            _coroutineRunner = coroutineRunner;
            _enemyCharacteristics = enemyCharacteristics;
            _playerTransform = playerTransform;
            _thisTransform = thisTransform;
        }
        public void Enter()
        {
            _coroutine = _coroutineRunner.StartCoroutine(Detecting());
        }

        public void Exit()
        {
            if (_coroutine != null)
                _coroutineRunner.StopCoroutine(_coroutine);
        }

        private IEnumerator Detecting()
        {
            while (DistanceToPlayer() > _enemyCharacteristics.RadiusOfDetection)
            {
                yield return null;
            }
            _enemyStateMachine.Enter<FollowState>();
        }

        private float DistanceToPlayer()
        {
            return Vector3.Distance(_playerTransform.position, _thisTransform.position);
        }
    }
}
