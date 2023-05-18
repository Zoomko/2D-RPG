using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.App.StateMachine
{
    public interface IState
    {
        void Exit();
    }

    public interface IParameterizedState: IState
    {
        void Enter<T>(T data);
    }

    public interface INoneParameterizedState: IState
    {
        void Enter();
    }
}
