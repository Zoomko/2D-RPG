using Assets.CodeBase.Data.StaticData.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [CreateAssetMenu(fileName = "Enemies", menuName = "StaticData/EnemiesCollection")]
    public class EnemiesStaticData:ScriptableObject
    {
        [SerializeField]
        private List<EnemyInfo> _enemies = new List<EnemyInfo>();
        private Dictionary<EnemyType, EnemyInfo> _enemiesDictionary;

        public Dictionary<EnemyType, EnemyInfo> Collection => _enemiesDictionary;

        private void OnEnable()
        {
            _enemiesDictionary = _enemies.ToDictionary(x => x.Type);
        }
    }
}
