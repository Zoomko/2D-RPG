using Assets.CodeBase.Data.StaticData;

namespace Assets.CodeBase.Services
{
    public interface IStaticDataService
    {
        EnemiesStaticData Enemies { get; }
        PlayerStaticData Player { get; }
        void Load();
    }
}