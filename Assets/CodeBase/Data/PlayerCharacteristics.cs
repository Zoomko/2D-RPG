using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Data
{
    [CreateAssetMenu(fileName = "PlayerCharacteristics", menuName = "StaticData/PlayerCharacteristics")]
    public class PlayerCharacteristics:ScriptableObject
    {
        public int HP;
        public float MovementSpeed;
        [Header("Attack")]
        public float RadiusOfAttack;
        public float AttacksInSecond;
        public int Damage;
        public float BulletSpeed;
    }
}
