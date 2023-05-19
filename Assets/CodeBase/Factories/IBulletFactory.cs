using Assets.CodeBase.Combat.Bullets;
using UnityEngine;

namespace Assets.CodeBase.Factories
{
    public interface IBulletFactory
    {
        GameObject Create(BulletParameters bulletParameters);
        void InitializePool();
    }
}