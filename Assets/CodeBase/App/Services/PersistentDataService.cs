using Assets.CodeBase.Data.PersistentData;
using Assets.CodeBase.Data.StaticData;
using System;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public class PersistentDataService
    {
        private readonly string _path;
        private readonly ILoadSaveDataFormat _loadSaveDataFormat;

        private PersistentGameData _persistentGameData;
        private bool _isDataEmpty = true;
        
        public event Action<PersistentGameData> Loading;
        public event Action<PersistentGameData> Saving;
        public PersistentGameData PersistentGameData => _persistentGameData;
        public bool IsDataEmpty => _isDataEmpty;

        public PersistentDataService(ILoadSaveDataFormat loadSaveDataFormat, Settings settings)
        {
            _path = settings.PersistentPath;
            _loadSaveDataFormat = loadSaveDataFormat;
        }

        public void Load()
        {
            _persistentGameData = _loadSaveDataFormat.Load<PersistentGameData>(_path);
            if (_persistentGameData != null)
            {
                _isDataEmpty = false;
                Loading?.Invoke(_persistentGameData);
            }
            else
            {
                _isDataEmpty = true;
            }
         }

        public void Save()
        {            
            _persistentGameData = new PersistentGameData();
            Saving?.Invoke(_persistentGameData);
            _loadSaveDataFormat.Save(_path, _persistentGameData);
        }
    }
}
