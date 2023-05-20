using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.App.Services.Input
{
    public class MobileInputService : IInputService, ITickable
    {
        private const string AttackKeyCode = "Fire";
        private const string AxisX = "Horizontal";
        private const string AxisY = "Vertical";

        public Vector2 MoveVector => new Vector2(SimpleInput.GetAxis(AxisX),SimpleInput.GetAxis(AxisY));
        
        public event Action FireButtonPressed;
        public event Action FireButtonReleased;

        public void Tick()
        {
            if(SimpleInput.GetButtonDown(AttackKeyCode))
            {
                FireButtonPressed?.Invoke();
            }

            if (SimpleInput.GetButtonUp(AttackKeyCode))
            {
                FireButtonReleased?.Invoke();
            }
        }
    }
}
