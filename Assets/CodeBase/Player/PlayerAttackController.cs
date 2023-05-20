using Assets.CodeBase.App.Services.Input;
using Assets.CodeBase.Combat.Bullets;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Factories;
using Assets.CodeBase.Inventory;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.CodeBase.Player
{
    public class PlayerAttackController : MonoBehaviour
    {
        private const string AttackLayer = "Enemy";
        private PlayerCharacteristics _playerCharacteristics;
        private IInputService _inputService;
        private WaitForSeconds _waitForSeconds;
        private IBulletFactory _bulletFactory;
        private InventoryController _inventoryController;

        private bool _isReloading = false;
        private bool _wantToAttack = false;
        private bool _canAttack = false;

        private Transform _target;
        private LayerMask _layerMask;

        private int maxCountOfEnemies = 10;
        private Collider2D[] _enemies;
        public void Contructor(PlayerCharacteristics playerCharacteristics, IInputService inputService, IBulletFactory bulletFactory, InventoryController inventoryController)
        {
            _playerCharacteristics = playerCharacteristics;
            _inputService = inputService;
            _bulletFactory = bulletFactory;
            _inventoryController = inventoryController;

            _inputService.FireButtonPressed += () => _wantToAttack = true;
            _inputService.FireButtonReleased += () => _wantToAttack = false;

            _enemies = new Collider2D[maxCountOfEnemies];
            _layerMask = 1 << LayerMask.NameToLayer(AttackLayer);

            _waitForSeconds = new WaitForSeconds(1f / _playerCharacteristics.AttacksInSecond); 
        }      

        private void Update()
        {
            if (!_isReloading && _wantToAttack && _canAttack && _inventoryController.CanSpendBullet())
            {
                Attack();
                _inventoryController.SpendBullet();
            }
        }

        private void FixedUpdate()
        {
            var hits = Physics2D.OverlapCircleNonAlloc(transform.position, _playerCharacteristics.RadiusOfAttack, _enemies, _layerMask);            
            if(hits > 0)
            {
                _target = GetClosestTarget(hits);               
                _canAttack = true;
            }
            else
            {              
                _canAttack = false;
            }    
        }

        private Transform GetClosestTarget(int numberOfEnemies)
        {
            float minDistance = float.MaxValue;
            Transform targetWithMinDistance = null;
            for(int i = 0; i < numberOfEnemies; i++)
            {
                var distance = Vector3.Distance(transform.position, _enemies[i].transform.position);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    targetWithMinDistance = _enemies[i].transform;
                }
            }
            return targetWithMinDistance;
        }

        private void Attack()
        {
            var bulletParameters = new BulletParameters()
            {
                Speed = _playerCharacteristics.BulletSpeed,
                Damage = _playerCharacteristics.Damage,
                Target = _target,
                LaunchPosition = transform.position                
            };
            _bulletFactory.Create(bulletParameters);
            StartCoroutine(Reloading());
        }

        private IEnumerator Reloading()
        {
            _isReloading = true;
            yield return _waitForSeconds;
            _isReloading = false;
        }
    }
}
