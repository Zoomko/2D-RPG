using System;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.App.Services.Input
{
    public interface IInputService
    {
        Vector2 MoveVector { get; }
        event Action FireButtonPressed;
        event Action FireButtonReleased;
    }
}
