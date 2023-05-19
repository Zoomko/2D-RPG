using Assets.CodeBase.Combat.Bullets;
using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Factories
{
    public class BulletFactory : IBulletFactory
    {
        private readonly IStaticDataService _staticDataService;
        private Pool _pool;
        public BulletFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        public void InitializePool()
        {
            _pool = new Pool(_staticDataService.Bullet);
        }
        public GameObject Create(BulletParameters bulletParameters)
        {
            var bulletGameObject = _pool.Get();
            var bullet = bulletGameObject.GetComponent<Bullet>();
            bulletGameObject.transform.position = bulletParameters.LaunchPosition;
            bullet.Contructor(bulletParameters);
            bullet.LaunchBullet();
            return bulletGameObject;
        }
    }
}
