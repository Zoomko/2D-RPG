using System;

namespace Assets.CodeBase.Player
{
    public interface IHealthable
    {
        int CurrentHP { get; }
        int MaxHP { get; }
        event Action HealthChanged;
    }
}