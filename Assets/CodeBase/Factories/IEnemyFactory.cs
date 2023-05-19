using Assets.CodeBase.Data.StaticData.Enemy;
using UnityEngine;

namespace Assets.CodeBase.Factories
{
    public interface IEnemyFactory
    {
        GameObject Create(EnemyType enemyType);
        void InitializePool();
    }
}