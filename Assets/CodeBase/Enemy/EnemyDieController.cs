using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    public class EnemyDieController:MonoBehaviour
    {
        public event Action Died;
        public void Die()
        {
            Died?.Invoke();
        }
    }
}
