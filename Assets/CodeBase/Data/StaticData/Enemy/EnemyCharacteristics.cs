using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [CreateAssetMenu(fileName = "EnemyCharacteristics", menuName = "StaticData/Enemy")]
    public class EnemyCharacteristics : ScriptableObject
    {
        public int HP;
        public float MovementSpeed;
        public int AttackDamage;
        public int AttacksPerSecond;
        public float RadiusOfAttack;
        public float RadiusOfDetection;
    }
}