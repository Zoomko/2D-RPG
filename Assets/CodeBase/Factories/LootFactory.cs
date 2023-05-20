using Assets.CodeBase.Data.StaticData.DropLoot;
using Assets.CodeBase.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Factories
{
    public class LootFactory : ILootFactory
    {
        private readonly IStaticDataService _staticDataService;
        private Pool _pool;
        public LootFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;         
        }
        public void InitializePool()
        {
            _pool = new Pool(_staticDataService.Loot);
        }
        public List<GameObject> Create(Loot loot, Vector3 position)
        {
            var lootItems = new List<GameObject>();
            foreach (var item in loot.DropAlways)
            {
                var lootItem = _pool.Get();
                lootItem.SetActive(true);
                lootItem.transform.position = position;
                var itemSpriteRenderer = lootItem.GetComponent<SpriteRenderer>();
                var lootInfo = lootItem.GetComponent<LootInfo>();
                itemSpriteRenderer.sprite = item.Item.Sprite;
                lootInfo.Count = item.Count;
                lootInfo.Id = item.Item.Id;
            }            
            return lootItems;
        }
        public void Despawn(GameObject lootItem)
        {
            lootItem.SetActive(false);
            _pool.Put(lootItem);
        }
    }
}
