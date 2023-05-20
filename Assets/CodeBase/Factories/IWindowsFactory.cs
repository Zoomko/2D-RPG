using UnityEngine;

namespace Assets.CodeBase.Factories
{
    public interface IWindowsFactory
    {
        GameObject CreateWindow(string name);
        T CreateWindow<T>(string name);
    }
}