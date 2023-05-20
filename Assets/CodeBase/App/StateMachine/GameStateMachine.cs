using Assets.CodeBase.App.Services;
using Assets.CodeBase.Factories;
using Assets.CodeBase.Inventory;
using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;

namespace Assets.CodeBase.App.StateMachine
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _currentState;
        public GameStateMachine(PersistentDataService persistentDataService,
                                IStaticDataService staticDataService,
                                ISceneService sceneService,
                                IPlayerFactory playerFactory,
                                IHUDFactory hudFactory,
                                IEnemyFactory enemyFactory,
                                IBulletFactory bulletFactory,
                                ILootFactory lootFactory,
                                InventoryController inventoryController)
        {
            _states = new Dictionary<Type, IState>()
            {
                {typeof(LoadStaticDataState), new LoadStaticDataState(
                    this,
                    staticDataService)},
                {typeof(LoadSceneState), new LoadSceneState(
                    this,
                    sceneService)},
                {typeof(CreateObjectsState), new CreateObjectsState(
                    this,
                    persistentDataService,
                    playerFactory,
                    enemyFactory,
                    hudFactory,
                    bulletFactory,
                    lootFactory,
                    inventoryController,
                    staticDataService)}
            };
        }

        public void Enter<T>() where T : INoneParameterizedState
        {
            if (!_states.ContainsKey(typeof(T)))
                throw new KeyNotFoundException();

            if (_currentState == null)
            {
                SetNoneParameterizedState<T>();
            }
            else
            {
                _currentState.Exit();
                SetNoneParameterizedState<T>();
            }
        }

        public void Enter<T1, T2>(T2 data) where T1 : IParameterizedState
        {
            if (!_states.ContainsKey(typeof(T1)))
                throw new KeyNotFoundException();
            if (_currentState == null)
            {
                SetParameterizedState<T1, T2>(data);
            }
            else
            {
                _currentState.Exit();
                SetParameterizedState<T1, T2>(data);
            }
        }

        private void SetParameterizedState<T1, T2>(T2 data) where T1 : IParameterizedState
        {
            var state = _states[typeof(T1)] as IParameterizedState;
            _currentState = state;
            state.Enter(data);
        }

        private void SetNoneParameterizedState<T>() where T : INoneParameterizedState
        {
            var state = _states[typeof(T)] as INoneParameterizedState;
            _currentState = state;
            state.Enter();
        }
    }
}
