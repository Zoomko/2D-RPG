using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.App
{
    public interface ISaveable<T>
    {
        void Save(T obj);
    }
}
