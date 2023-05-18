using System;

namespace Assets.CodeBase.App.Services
{
    public interface ISceneService
    {
        void Load(string name, Action onLoaded);
    }
}