using Assets.CodeBase.Data.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        private EnemyCharacteristics _enemyCharacteristics;
        public void Contructor(EnemyCharacteristics enemyCharacteristics)
        {
            _enemyCharacteristics = enemyCharacteristics;
        }
        public void Move(Vector2 directionVector)
        {
            var moveVector = directionVector * _enemyCharacteristics.MovementSpeed * Time.deltaTime;
            transform.Translate(moveVector);
        }
    }
}
