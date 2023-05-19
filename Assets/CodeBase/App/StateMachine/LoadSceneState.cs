using Assets.CodeBase.App.Services;
using System;

namespace Assets.CodeBase.App.StateMachine
{
    public class LoadSceneState : IParameterizedState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneService _sceneService;

        public LoadSceneState(GameStateMachine gameStateMachine, ISceneService sceneService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneService = sceneService;
        }
        public void Enter<T>(T data)
        {
            string sceneName = data as string;
            if (sceneName == null)
                throw new ArgumentException();
            _sceneService.Load(sceneName, OnLoaded);
        }
        public void OnLoaded()
        {
            _gameStateMachine.Enter<CreateObjectsState>();
        }
        public void Exit()
        {
        }
    }
}
