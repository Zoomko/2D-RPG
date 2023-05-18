using Assets.CodeBase.App.Services;
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
                                ISceneService sceneService)
        {
            _states = new Dictionary<Type, IState>()
            {
                {typeof(LoadStaticDataState), new LoadStaticDataState(this, staticDataService)},
                {typeof(LoadPersistentDataState), new LoadPersistentDataState(this, persistentDataService)},
                {typeof(LoadSceneState), new LoadSceneState(this, sceneService)}
            };
        }

        public void Enter<T>() where T : INoneParameterizedState
        {
            if (!_states.ContainsKey(typeof(T)))
                throw new KeyNotFoundException();

            if (_currentState == null)
            {
                var state = _states[typeof(T)] as INoneParameterizedState;
                _currentState = state;
                state.Enter();
            }
            else
            {
                _currentState.Exit();
                var state = _states[typeof(T)] as INoneParameterizedState;
                _currentState = state;
                state.Enter();
            }
        }

        public void Enter<T1, T2>(T2 data) where T1 : IParameterizedState
        {
            if (!_states.ContainsKey(typeof(T1)))
                throw new KeyNotFoundException();
            if (_currentState == null)
            {
                var state = _states[typeof(T1)] as IParameterizedState;
                _currentState = state;
                state.Enter(data);
            }
            else
            {
                _currentState.Exit();
                var state = _states[typeof(T1)] as IParameterizedState;
                _currentState = state;
                state.Enter(data);
            }
        }
    }
}
