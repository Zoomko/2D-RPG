using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.App.StateMachine
{
    public class LoadStaticDataState : INoneParameterizedState
    {
        private const string SceneToLoad = "Game";
        private readonly GameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;

        public LoadStaticDataState(GameStateMachine gameStateMachine, IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
        }
        public void Enter()
        {
            _staticDataService.Load();
            _gameStateMachine.Enter<LoadSceneState, string>(SceneToLoad);
        }

        public void Exit()
        {
           
        }
    }
}
