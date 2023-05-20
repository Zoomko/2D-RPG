using Assets.CodeBase.Data.StaticData.Enemy;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    public class EnemyInfo : MonoBehaviour
    {
        public bool IsInitialized = false;
        public EnemyType Type { get; set; }
    }
}
