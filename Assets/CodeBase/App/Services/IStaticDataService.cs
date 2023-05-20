using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Inventory.Item;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public interface IStaticDataService
    {
        EnemiesStaticData Enemies { get; }
        PlayerStaticData Player { get; }
        GameObject HUD { get; }
        GameObject Bullet { get; }
        GameObject Loot { get; }
        WindowsObjects Windows { get; }
        Dictionary<int, ItemData> Items { get; }
        Dictionary<string, ItemData> ItemsWithKeyNames { get; }
        void Load();
    }
}