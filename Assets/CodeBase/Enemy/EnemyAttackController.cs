using Assets.CodeBase.Combat;
using Assets.CodeBase.Data.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    public class EnemyAttackController : MonoBehaviour
    {
        private EnemyCharacteristics _enemyCharacteristics;      

        public void Contructor(EnemyCharacteristics enemyCharacteristics)
        {
            _enemyCharacteristics = enemyCharacteristics;            
        }

        public void Attack(IDamagable player)
        {
            player.GetDamage(_enemyCharacteristics.AttackDamage);
        }
    }
}
