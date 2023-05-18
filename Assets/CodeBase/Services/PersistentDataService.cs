using Assets.CodeBase.Data.PersistentData;
using System;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public class PersistentDataService
    {
        private readonly string _path;
        private readonly ILoadSaveDataFormat _loadSaveDataFormat;
        private PersistentGameData _persistentGameData;
        
        public event Action<PersistentGameData> Loading;
        public event Action<PersistentGameData> Saving;
        public PersistentGameData PersistentGameData => _persistentGameData;

        public PersistentDataService(ILoadSaveDataFormat loadSaveDataFormat, string path)
        {
            _path = path;
            _loadSaveDataFormat = loadSaveDataFormat;
        }

        public void Load()
        {
            _persistentGameData = _loadSaveDataFormat.Load<PersistentGameData>(_path);
            Loading?.Invoke(_persistentGameData);
        }

        public void Save()
        {
            Saving?.Invoke(_persistentGameData);
            _loadSaveDataFormat.Save(_path, _persistentGameData);
        }
    }
}
