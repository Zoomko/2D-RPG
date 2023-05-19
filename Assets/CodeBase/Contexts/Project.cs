#define PRODUCTION
using Assets.CodeBase.App.Services;
using Assets.CodeBase.App.Services.Input;
using Assets.CodeBase.App.StateMachine;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Factories;
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
        Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
        Container.Bind<IHUDFactory>().To<HUDFactory>().AsSingle();
        Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
        Container.Bind<IBulletFactory>().To<BulletFactory>().AsSingle();
        RegisterInputService(); 
    }

    private void RegisterInputService()
    {
#if PRODUCTION
        Container.Bind(typeof(IInputService), typeof(ITickable)).To<MobileInputService>().AsSingle();
#endif
#if DEVELOPMENT
        Container.Bind(typeof(IInputService), typeof(ITickable)).To<StandaloneInputService>().AsSingle();
#endif
    }
}