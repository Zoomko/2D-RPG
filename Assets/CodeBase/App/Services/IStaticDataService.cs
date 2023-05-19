using Assets.CodeBase.Data.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public interface IStaticDataService
    {
        EnemiesStaticData Enemies { get; }
        PlayerStaticData Player { get; }
        GameObject HUD { get; }
        GameObject Bullet { get; }
        void Load();
    }
}