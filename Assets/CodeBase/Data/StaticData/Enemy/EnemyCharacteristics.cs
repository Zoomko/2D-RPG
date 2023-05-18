using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [CreateAssetMenu(fileName = "EnemyCharacteristics", menuName = "StaticData/Enemy")]
    public class EnemyCharacteristics : ScriptableObject
    {
        public int HP;
    }
}