using System;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.App.Services.Input
{
    public class UIInputService : ITickable, IUIInputService
    {
        private const string InventoryKeyCode = "Inventory";

        public event Action InventoryButtonPressed;
        public void Tick()
        {
            if (SimpleInput.GetButtonDown(InventoryKeyCode))
            {
                Debug.Log("Button pressed");
                InventoryButtonPressed?.Invoke();
            }
        }
    }
}
