using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.CodeBase.App
{
    public class Pool
    {
        private GameObject _poolObject;
        private Queue<GameObject> _activeObjects;
        private Queue<GameObject> _unactiveObjects;      
        public Pool(GameObject obj)
        {
            _poolObject = obj;
            _activeObjects = new Queue<GameObject>();
            _unactiveObjects = new Queue<GameObject>();
        }

        public GameObject Get()
        {
            if (_unactiveObjects.Count > 0)
            {
                return _unactiveObjects.Dequeue();
            }
            else
            {
                var newGameObject = GameObject.Instantiate(_poolObject);
                _activeObjects.Enqueue(newGameObject);
                return newGameObject;
            }
        }
        public void Put(GameObject obj)
        {
            _unactiveObjects.Enqueue(obj);
        }
    }
}
