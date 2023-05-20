#define PRODUCTION
using Assets.CodeBase.App.Services;
using Assets.CodeBase.App.Services.Input;
using Assets.CodeBase.App.StateMachine;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Factories;
using Assets.CodeBase.Helper;
using Assets.CodeBase.Inventory;
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
        RegisterFactories();
        RegisterInputService();
        RegisterUIControllers();
    }

    private void RegisterUIControllers()
    {
        Container.Bind<InventoryController>().AsSingle();
    }

    private void RegisterFactories()
    {
        Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
        Container.Bind<IHUDFactory>().To<HUDFactory>().AsSingle();
        Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
        Container.Bind<IBulletFactory>().To<BulletFactory>().AsSingle();
        Container.Bind<ILootFactory>().To<LootFactory>().AsSingle();
        Container.Bind<IWindowsFactory>().To<WindowsFactory>().AsSingle();
    }

    private void RegisterInputService()
    {
#if PRODUCTION
        Container.Bind(typeof(IInputService), typeof(ITickable)).To<MobileInputService>().AsSingle();
#endif
#if DEVELOPMENT
        Container.Bind(typeof(IInputService), typeof(ITickable)).To<StandaloneInputService>().AsSingle();
#endif
        Container.Bind(typeof(IUIInputService), typeof(ITickable)).To<UIInputService>().AsSingle();
    }
}