using System;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData.Enemy
{
    [Serializable]
    public class EnemyInfo
    {
        public EnemyType Type;
        public EnemyCharacteristics EnemyCharacteristics;
        public GameObject EnemyPrefab;
    }
}
