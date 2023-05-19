using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Enemy
{
    public interface IEnemyState
    {
        void Enter();
        void Exit();
    }
}
