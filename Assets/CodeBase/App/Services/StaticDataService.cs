using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Helper;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public class StaticDataService : IStaticDataService
    {
        private EnemiesStaticData _enemiesStaticData;
        private PlayerStaticData _playerStaticData;
        private GameObject _hud;
        private GameObject _bullet;
        public EnemiesStaticData Enemies => _enemiesStaticData;
        public PlayerStaticData Player => _playerStaticData;
        public GameObject HUD => _hud;
        public GameObject Bullet => _bullet;

        public void Load()
        {
            LoadEnemies();
            LoadPlayer();
            LoadHUD();
            LoadBullet();
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

    }
}
