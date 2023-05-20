using Assets.CodeBase.Data.StaticData.DropLoot;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Factories
{
    public interface ILootFactory
    {
        List<GameObject> Create(Loot loot, Vector3 position);
        void InitializePool();
        void Despawn(GameObject gameObject);
    }
}