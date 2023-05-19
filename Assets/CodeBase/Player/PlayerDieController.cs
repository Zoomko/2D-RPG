using System;
using UnityEngine;

namespace Assets.CodeBase.Player
{
    public class PlayerDieController : MonoBehaviour
    {
        public event Action Died;

        public void Die()
        {
            Died?.Invoke();
        }
    }
}
