using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [CreateAssetMenu(fileName = "PlayerCharacteristics", menuName = "StaticData/PlayerCharacteristics")]
    public class PlayerCharacteristics : ScriptableObject
    {
        public int HP;
        public float MovementSpeed;
        [Header("Attack")]
        public float RadiusOfAttack;
        public float AttacksInSecond;
        public int Damage;
        public float BulletSpeed;
        [Header("Loot")]
        public float LootGrabRadius;
    }
}
