using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Factories
{
    public class Pool
    {
        private GameObject _poolObject;
        private List<GameObject> _activeObjects;
        private Queue<GameObject> _unactiveObjects;
        public Pool(GameObject obj)
        {
            _poolObject = obj;
            _activeObjects = new List<GameObject>();
            _unactiveObjects = new Queue<GameObject>();
        }

        public List<GameObject> ActiveObjects  => _activeObjects;

        public Queue<GameObject> UnactiveObjects => _unactiveObjects; 

        public GameObject Get()
        {
            if (_unactiveObjects.Count > 0)
            {
                var gameObject = _unactiveObjects.Dequeue();
                _activeObjects.Add(gameObject);
                return gameObject;
            }
            else
            {
                var newGameObject = Object.Instantiate(_poolObject);
                _activeObjects.Add(newGameObject);
                return newGameObject;
            }
        }
        public void Put(GameObject obj)
        {
            _activeObjects.Remove(obj);
            _unactiveObjects.Enqueue(obj);
        }
    }
}
