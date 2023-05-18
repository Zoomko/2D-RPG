using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Helper;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public class StaticDataService : IStaticDataService
    {
        private EnemiesStaticData _enemiesStaticData;
        private PlayerStaticData _playerStaticData;
        public EnemiesStaticData Enemies => _enemiesStaticData;
        public PlayerStaticData Player => _playerStaticData;

        public void Load()
        {
            LoadEnemies();
            LoadPlayer();
        }

        public void LoadEnemies()
        {
            _enemiesStaticData = Resources.Load<EnemiesStaticData>(Paths.EnemiesStaticDataPath);
        }

        public void LoadPlayer()
        {
            _playerStaticData = Resources.Load<PlayerStaticData>(Paths.PlayerStaticDataPath);
        }

    }
}
