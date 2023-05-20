using Assets.CodeBase.Inventory.Item;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData.DropLoot
{
    [CreateAssetMenu(fileName = "DropLoot", menuName = "DropLoot")]
    public class Loot : ScriptableObject
    {
        public List<LootWithoutProbability> DropAlways;
        public List<LootWithProbability> DropLootWithProbability;      
    }
}
