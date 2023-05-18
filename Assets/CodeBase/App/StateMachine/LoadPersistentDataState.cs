using Assets.CodeBase.Services;

namespace Assets.CodeBase.App.StateMachine
{
    public class LoadPersistentDataState : INoneParameterizedState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly PersistentDataService _persistentDataService;

        public LoadPersistentDataState(GameStateMachine gameStateMachine, PersistentDataService persistentDataService)
        {
            _gameStateMachine = gameStateMachine;
            _persistentDataService = persistentDataService;
        }

        public void Enter()
        {
            _persistentDataService.Load();
        }

        public void Exit()
        {

        }
    }
}
