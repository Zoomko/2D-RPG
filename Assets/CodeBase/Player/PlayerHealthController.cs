using Assets.CodeBase.App;
using Assets.CodeBase.App.Services.Input;
using Assets.CodeBase.Combat;
using Assets.CodeBase.Data;
using Assets.CodeBase.Data.PersistentData;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.CodeBase.Player
{
    [RequireComponent(typeof(PlayerDieController))]
    public class PlayerHealthController : MonoBehaviour, IDamagable, ILoadable<PlayerData>, ISaveable<PlayerData>
    {
        private PlayerDieController _playerDieController;
        private PlayerCharacteristics _playerCharacteristics;
        private int _maxHP;
        private int _currentHP;

        public event Action<int, int, int> HPChanged;

        public void Contructor(PlayerCharacteristics playerCharacteristics)
        {
            _playerCharacteristics = playerCharacteristics;
            _maxHP = _playerCharacteristics.HP;
            _currentHP = _maxHP;
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
            HPChanged?.Invoke(result, _maxHP, damage);
            _currentHP = result;
        }

        public void Load(PlayerData playerData)
        {
            _currentHP = playerData.HP;
        }

        public void Save(PlayerData playerData)
        {
            playerData.HP = _currentHP;
        }
    }
}
