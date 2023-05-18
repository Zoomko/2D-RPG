using Assets.CodeBase.App.Services;
using Assets.CodeBase.App.StateMachine;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Helper;
using Assets.CodeBase.Services;
using Zenject;

public class Project : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameStateMachine>().AsSingle();
        Container.Bind<Settings>().FromResource(Paths.SettingsDataPath);
        Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        Container.Bind<ILoadSaveDataFormat>().To<JsonDataService>().AsSingle();
        Container.Bind<ISceneService>().To<SceneService>().AsSingle();
        Container.Bind<CoroutineRunner>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<PersistentDataService>().AsSingle();
    }
}