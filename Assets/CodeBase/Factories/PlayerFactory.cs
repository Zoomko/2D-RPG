using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Factories
{
    internal class PlayerFactory
    {
        private PlayerStaticData _playerStaticData;
        public PlayerFactory(IStaticDataService staticDataService)
        {
            _playerStaticData = staticDataService.Player;
        }
        public GameObject Create()
        {
            return null;
        }
    }
}
