using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Factories
{
    public class WindowsFactory : IWindowsFactory
    {
        private readonly IStaticDataService _staticDataService;

        public WindowsFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public GameObject CreateWindow(string name)
        {
            var windowObject = GameObject.Instantiate(_staticDataService.Windows.Collection[name]);
            return windowObject;
        }

        public T CreateWindow<T>(string name)
        {
            var windowObject = GameObject.Instantiate(_staticDataService.Windows.Collection[name]);
            var component = windowObject.GetComponent<T>();
            return component;
        }

    }
}
