using Assets.CodeBase.App.Services;
using Assets.CodeBase.Combat;
using Assets.CodeBase.Data.StaticData;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Enemy.StateMachine
{
    public class AttackState : IEnemyState
    {
        private readonly EnemyStateMachine _enemyStateMachine;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly EnemyCharacteristics _enemyCharacteristics;
        private readonly EnemyAttackController _enemyAttackController;
        private readonly Transform _playerTransform;
        private readonly Transform _thisTransform;
        private readonly IDamagable _playerDamagable;

        private Coroutine _coroutine;   

        public AttackState(EnemyStateMachine enemyStateMachine,
                           CoroutineRunner coroutineRunner,
                           EnemyCharacteristics enemyCharacteristics,
                           EnemyAttackController enemyAttackController,
                           Transform playerTransform,
                           Transform thisTransform)
        {
            _enemyStateMachine = enemyStateMachine;
            _coroutineRunner = coroutineRunner;
            _enemyCharacteristics = enemyCharacteristics;
            _enemyAttackController = enemyAttackController;
            _playerTransform = playerTransform;
            _thisTransform = thisTransform;
            _playerDamagable = _playerTransform.gameObject.GetComponent<IDamagable>();
        }
        public void Enter()
        {      
            Attack(_playerDamagable);
        }

        public void Exit()
        {
            if (_coroutine != null)
                _coroutineRunner.StopCoroutine(_coroutine);     
        }

        private void Attack(IDamagable _playerDamagable)
        {
            _enemyAttackController.Attack(_playerDamagable);
            _coroutine = _coroutineRunner.StartCoroutine(AttackReload());
        }

        private IEnumerator AttackReload()
        {
            var startTime = Time.time;
            var reloadAttackTime = 1f / _enemyCharacteristics.AttacksPerSecond;
            var stopTime = startTime + reloadAttackTime;

            while (Time.time < stopTime && DistanceToPlayer() < _enemyCharacteristics.RadiusOfAttack)
            {
                yield return null;
            }

            if (DistanceToPlayer() > _enemyCharacteristics.RadiusOfAttack)
                _enemyStateMachine.Enter<FollowState>();
            else
                Attack(_playerDamagable);
        }

        private float DistanceToPlayer()
        {
            return Vector3.Distance(_playerTransform.position, _thisTransform.position);
        }
    }
}
