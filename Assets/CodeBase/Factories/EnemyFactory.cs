using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Data.StaticData.Enemy;
using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Factories
{
    public class EnemyFactory
    {
        private EnemiesStaticData _enemies;
        public EnemyFactory(IStaticDataService staticDataService)
        {
            _enemies = staticDataService.Enemies;
        }
        public GameObject Create(EnemyType enemyType)
        {
            return null;
        }
    }
}
