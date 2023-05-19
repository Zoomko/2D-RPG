using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.App.Services.Input
{
    public class StandaloneInputService : IInputService, ITickable
    {
        public Vector2 MoveVector 
            => new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical")).normalized;

        public event Action FireButtonPressed;
        public event Action FireButtonReleased;

        public void Tick()
        {
            if(UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
            {
                FireButtonPressed?.Invoke();
            }

            if(UnityEngine.Input.GetKeyUp(KeyCode.Mouse0))
            {
                FireButtonReleased?.Invoke();
            }
        }
    }
}
