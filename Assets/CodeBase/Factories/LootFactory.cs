using Assets.CodeBase.App.Services.Probability;
using Assets.CodeBase.Data.StaticData.DropLoot;
using Assets.CodeBase.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Factories
{
    public class LootFactory : ILootFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly ProbabilityLootService _probabilityLootService;
        private Pool _pool;
        public LootFactory(IStaticDataService staticDataService, ProbabilityLootService probabilityLootService)
        {
            _staticDataService = staticDataService;
            _probabilityLootService = probabilityLootService;
        }

        public void InitializePool()
        {
            _pool = new Pool(_staticDataService.Loot);
        }

        public List<GameObject> Create(Loot loot, Vector3 position)
        {
            var lootItems = new List<GameObject>();
            CreateAlwaysDropLoot(loot, position);
            var probabilityItem = _probabilityLootService.GetLoot(loot);
            CreateLootItem(probabilityItem,position);
            return lootItems;
        }

        public void Despawn(GameObject lootItem)
        {
            lootItem.SetActive(false);
            _pool.Put(lootItem);
        }

        private void CreateAlwaysDropLoot(Loot loot, Vector3 position)
        {
            foreach (var item in loot.DropAlways)
            {
                CreateLootItem(item, position);
            }
        }

        private void CreateLootItem(LootWithoutProbability item, Vector3 position)
        {
            var lootItem = _pool.Get();
            lootItem.SetActive(true);
            lootItem.transform.position = position + new Vector3(Random.value,Random.value,0f);            
            var itemSpriteRenderer = lootItem.GetComponent<SpriteRenderer>();
            var lootInfo = lootItem.GetComponent<LootInfo>();
            itemSpriteRenderer.sprite = item.Item.Sprite;
            lootInfo.Count = item.Count;
            lootInfo.Id = item.Item.Id;
        }
    }
}
