using Assets.CodeBase.Combat;
using Assets.CodeBase.Data;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Player;
using System;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyDieController))]
    public class EnemyHealthController : MonoBehaviour, IDamagable
    {
        private EnemyDieController _enemyDieController;
        private EnemyCharacteristics _enemyCharacteristics;
        private int _maxHP;
        private int _currentHP;

        public event Action<int, int, int> HPChanged;

        public void Contructor(EnemyCharacteristics enemyCharacteristics)
        {
            _enemyCharacteristics = enemyCharacteristics;
            _maxHP = _enemyCharacteristics.HP;
            _currentHP = _maxHP;
        }
        private void Awake()
        {
            _enemyDieController = GetComponent<EnemyDieController>();
        }

        public void GetDamage(int damage)
        {
            var result = Mathf.Max(0, _currentHP - damage);
            if (result == 0)
            {
                _enemyDieController.Die();
            }
            HPChanged?.Invoke(result, _maxHP, damage);
            _currentHP = result;
        }
    }
}
