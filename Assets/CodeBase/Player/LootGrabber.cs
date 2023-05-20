using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Factories;
using Assets.CodeBase.Inventory;
using UnityEngine;

namespace Assets.CodeBase.Player
{
    public class LootGrabber : MonoBehaviour
    {
        private const string LootLayer = "Loot";
        private InventoryController _inventoryController;
        private PlayerStaticData _playerStaticData;
        private ILootFactory _lootFactory;
        private LayerMask _layerMask;
        private int _maxLoot = 10;
        private Collider2D[] _loot;
        public void Constructor(InventoryController inventoryController, PlayerStaticData playerStaticData, ILootFactory lootFactory)
        {
            _inventoryController = inventoryController;
            _playerStaticData = playerStaticData;
            _lootFactory = lootFactory;
            _layerMask = 1 << LayerMask.NameToLayer(LootLayer);
            _loot = new Collider2D[_maxLoot];
        }
        private void FixedUpdate()
        {
            int lootCount = Physics2D.OverlapCircleNonAlloc(transform.position, _playerStaticData.PlayerCharacteristics.LootGrabRadius, _loot, _layerMask);           
            if (lootCount > 0)
            {
                for (int i = 0; i < lootCount; i++)
                {
                    if (_loot[i].gameObject.TryGetComponent(out LootInfo lootInfo))
                    {
                        _inventoryController.AddItem(lootInfo.Id, lootInfo.Count);
                        _lootFactory.Despawn(_loot[i].gameObject);
                    }
                }
            }
        }
    }
}
