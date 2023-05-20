using Assets.CodeBase.Data.StaticData.DropLoot;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.App.Services.Probability
{
    public class ProbabilityLootService
    {   
        public LootWithoutProbability GetLoot(Loot loot)
        {
            var lootWithoutProbability = new LootWithoutProbability();

            var probabilityLootObjects = CreateProbabilityObjects(loot);
            var randomValue = Random.value;
            var choosenObject = probabilityLootObjects.Find(x => x.InInterval(randomValue));

            lootWithoutProbability.Item = choosenObject.LootWithoutProbability.Item;
            lootWithoutProbability.Count = choosenObject.LootWithoutProbability.Count;

            return lootWithoutProbability;
        }

        private List<ProbabilityLootObject> CreateProbabilityObjects(Loot loot)
        {
            List<ProbabilityLootObject> probabilityLootObjects = new List<ProbabilityLootObject>();
            float probabilityEdge = 0f;
            foreach (var item in loot.DropLootWithProbability)
            {
                var startInterval = probabilityEdge;
                probabilityEdge += item.Probability;
                var endInterval = probabilityEdge;
                probabilityLootObjects.Add(new ProbabilityLootObject(startInterval, endInterval, item));
            }
            return probabilityLootObjects;
        }
    }
}
