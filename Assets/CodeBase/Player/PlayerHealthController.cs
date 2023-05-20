using Assets.CodeBase.App;
using Assets.CodeBase.App.Services.Input;
using Assets.CodeBase.Combat;
using Assets.CodeBase.Data.PersistentData;
using Assets.CodeBase.Data.StaticData;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.CodeBase.Player
{
    [RequireComponent(typeof(PlayerDieController))]
    public class PlayerHealthController : MonoBehaviour, IDamagable, IHealthable, ILoadable<PlayerData>, ISaveable<PlayerData>
    {
        private PlayerDieController _playerDieController;
        private PlayerCharacteristics _playerCharacteristics;
        private int _currentHP;
        private int _maxHP;

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

        public void Contructor(PlayerCharacteristics playerCharacteristics)
        {
            _playerCharacteristics = playerCharacteristics;
            _maxHP = _playerCharacteristics.HP;
            CurrentHP = _maxHP;
        }
        private void Awake()
        {
            _playerDieController = GetComponent<PlayerDieController>();
        }

        public void GetDamage(int damage)
        {
            var result = Mathf.Max(0, _currentHP - damage);
            if (result == 0)
            {
                _playerDieController.Die();
            }
            DamageGotten?.Invoke(damage);
            CurrentHP = result;
        }

        public void Load(PlayerData playerData)
        {
            CurrentHP = playerData.HP;
        }

        public void Save(PlayerData playerData)
        {
            playerData.HP = _currentHP;
        }
    }
}
