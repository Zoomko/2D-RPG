using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Helper;
using Assets.CodeBase.Inventory.Item;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

namespace Assets.CodeBase.Services
{
    public class StaticDataService : IStaticDataService
    {
        private EnemiesStaticData _enemiesStaticData;
        private PlayerStaticData _playerStaticData;
        private GameObject _hud;
        private GameObject _bullet;
        private GameObject _loot;
        private WindowsObjects _windows;
        private Dictionary<int, ItemData> _items;
        private Dictionary<string, ItemData> _itemsWithKeyNames;
        public EnemiesStaticData Enemies => _enemiesStaticData;
        public PlayerStaticData Player => _playerStaticData;
        public GameObject HUD => _hud;
        public GameObject Bullet => _bullet;
        public GameObject Loot => _loot;
        public Dictionary<int, ItemData> Items => _items;

        public WindowsObjects Windows => _windows;

        public Dictionary<string, ItemData> ItemsWithKeyNames => _itemsWithKeyNames;

        public void Load()
        {
            LoadEnemies();
            LoadPlayer();
            LoadHUD();
            LoadBullet();
            LoadLoot();
            LoadWindows();
            LoadItems();
        }

        public void LoadEnemies()
        {
            _enemiesStaticData = Resources.Load<EnemiesStaticData>(Paths.EnemiesStaticDataPath);
        }

        public void LoadPlayer()
        {
            _playerStaticData = Resources.Load<PlayerStaticData>(Paths.PlayerStaticDataPath);
        }
        public void LoadHUD()
        {
            _hud = Resources.Load<GameObject>(Paths.HUDDataPath);
        }
        public void LoadBullet()
        {
            _bullet = Resources.Load<GameObject>(Paths.BulletPath);
        }
        public void LoadLoot()
        {
            _loot = Resources.Load<GameObject>(Paths.LootPath);
        }
        public void LoadWindows()
        {
            _windows = Resources.Load<WindowsObjects>(Paths.WindowsPath);
        }
        public void LoadItems()
        {
            var items = Resources.LoadAll<ItemData>(Paths.ItemsPath);
            _items = items.ToDictionary(x => x.Id);
            _itemsWithKeyNames = items.ToDictionary(x => x.Name);
        }

    }
}
