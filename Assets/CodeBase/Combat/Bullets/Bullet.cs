using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Combat.Bullets
{
    public class Bullet:MonoBehaviour
    {
        private BulletParameters _parameters;
        public void Contructor(BulletParameters bulletParameters)
        {
            _parameters = bulletParameters;
        }
        public void LaunchBullet()
        {
            StartCoroutine(Flying());
        }
        private IEnumerator Flying()
        {
            var path = 0f;
            while(path < 1f)
            {
                var deltaDistance = _parameters.Speed * Time.deltaTime;
                var distanceToTarget = Vector3.Distance(transform.position, _parameters.Target.position);
                path = deltaDistance / distanceToTarget;
                transform.position = Vector3.Lerp(transform.position, _parameters.Target.position, path);
                yield return null;
            }
            var damagable = _parameters.Target.gameObject.GetComponent<IDamagable>();
            damagable.GetDamage(_parameters.Damage);
        }
    }
}
