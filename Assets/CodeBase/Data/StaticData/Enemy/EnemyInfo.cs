using Assets.CodeBase.Data.StaticData.DropLoot;
using System;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData.Enemy
{
    [Serializable]
    public class EnemyInfo
    {
        public EnemyType Type;
        public EnemyCharacteristics EnemyCharacteristics;
        public Loot Loot;
        public GameObject EnemyPrefab;
    }
}
