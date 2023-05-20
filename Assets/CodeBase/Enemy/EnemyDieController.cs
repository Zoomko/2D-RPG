using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Data.StaticData.DropLoot;
using Assets.CodeBase.Factories;
using System;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    public class EnemyDieController : MonoBehaviour
    {
        public event Action<GameObject> Died;
        private ILootFactory _lootFactory;
        private Loot _loot;
        public void Constructor(ILootFactory lootFactory, Loot loot)
        {
            _lootFactory = lootFactory;
            _loot = loot;
        }

        public void Die()
        {
            Died?.Invoke(gameObject);
            _lootFactory.Create(_loot, transform.position);
        }
    }
}
