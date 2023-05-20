using Assets.CodeBase.Inventory.Item;
using System;

namespace Assets.CodeBase.Data.StaticData.DropLoot
{
    [Serializable]
    public class LootWithProbability
    {
        public ItemData Item;
        public float Probability;
        public int Count;
    }
}
