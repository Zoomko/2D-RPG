using Assets.CodeBase.Inventory.Item;
using System;

namespace Assets.CodeBase.Data.StaticData.DropLoot
{
    [Serializable]
    public class LootWithoutProbability
    {
        public ItemData Item;
        public int Count;
    }
}
