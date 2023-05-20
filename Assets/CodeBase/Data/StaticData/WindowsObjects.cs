using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [CreateAssetMenu(fileName = "Windows", menuName = "Windows")]
    public class WindowsObjects : ScriptableObject
    {
        [SerializeField]
        private List<WindowsObject> _windowsObjects;
        private Dictionary<string, GameObject> _windows;
        public Dictionary<string, GameObject> Collection => _windows;
        private void OnEnable()
        {
            _windows = new Dictionary<string, GameObject>();
            foreach (var window in _windowsObjects)
            {
                _windows.Add(window.Name, window.Window);
            }
        }
    }
}
