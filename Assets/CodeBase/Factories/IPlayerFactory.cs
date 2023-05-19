using UnityEngine;

namespace Assets.CodeBase.Factories
{
    public interface IPlayerFactory
    {
        GameObject Player { get; }

        GameObject Create();
    }
}