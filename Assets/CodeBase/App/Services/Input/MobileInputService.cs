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
        public Vector2 MoveVector => new Vector2(SimpleInput.GetAxis("Horizontal"),SimpleInput.GetAxis("Vertical"));
        
        public event Action FireButtonPressed;
        public event Action FireButtonReleased;

        public void Tick()
        {
            if(SimpleInput.GetButtonDown("Fire"))
            {
                FireButtonPressed?.Invoke();
            }

            if (SimpleInput.GetButtonUp("Fire"))
            {
                FireButtonReleased?.Invoke();
            }
        }
    }
}
