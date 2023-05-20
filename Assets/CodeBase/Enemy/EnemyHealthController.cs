using Assets.CodeBase.Combat;
using Assets.CodeBase.Data;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Player;
using System;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyDieController))]
    public class EnemyHealthController : MonoBehaviour, IDamagable, IHealthable
    {
        private EnemyDieController _enemyDieController;
        private EnemyCharacteristics _enemyCharacteristics;
        private int _maxHP;
        private int _currentHP;

        public int CurrentHP
        {
            get { return _currentHP; }
            private set
            {
                _currentHP = value;
                HealthChanged?.Invoke();
            }
        }

        public int MaxHP => _maxHP;

        public event Action<int> DamageGotten;
        public event Action HealthChanged;

        public void Contructor(EnemyCharacteristics enemyCharacteristics)
        {
            _enemyCharacteristics = enemyCharacteristics;
            _maxHP = _enemyCharacteristics.HP;
            CurrentHP = _maxHP;
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
            DamageGotten?.Invoke(damage);
            CurrentHP = result;
        }
    }
}
