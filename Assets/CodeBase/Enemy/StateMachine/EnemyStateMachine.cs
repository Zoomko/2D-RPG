using Assets.CodeBase.App.Services;
using Assets.CodeBase.App.StateMachine;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Factories;
using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Enemy.StateMachine
{
    public class EnemyStateMachine : MonoBehaviour
    {
        private Dictionary<Type, IEnemyState> _states;
        private IEnemyState _currentState;       
        public void Contructor(CoroutineRunner coroutineRunner,
                               EnemyCharacteristics enemyCharacteristics,
                               Transform playerTransform,
                               EnemyAttackController attackController,
                               EnemyMovementController movementController)
        {          

            _states = new Dictionary<Type, IEnemyState>()
            {
                {typeof(DetectState), new DetectState(this, coroutineRunner, enemyCharacteristics, playerTransform, transform) },
                {typeof(FollowState), new FollowState(this, coroutineRunner, enemyCharacteristics, movementController, playerTransform, transform) },
                {typeof(AttackState), new AttackState(this, coroutineRunner, enemyCharacteristics, attackController, playerTransform, transform) }
            };

            Enter<DetectState>();
        }        
        public void Enter<T>() where T : IEnemyState
        {
            if (!_states.ContainsKey(typeof(T)))
                throw new KeyNotFoundException();

            if (_currentState == null)
            {
                SetState<T>();
            }
            else
            {
                _currentState.Exit();
                SetState<T>();
            }
        }
        private void SetState<T>() where T : IEnemyState
        {
            var state = _states[typeof(T)];
            _currentState = state;
            state.Enter();
        }
    }
}
