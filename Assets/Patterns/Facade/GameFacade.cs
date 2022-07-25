using System;
using Patterns.Adapter;
using UnityEngine;

namespace Patterns.Facade
{
    public class GameFacade : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private PlayerSpawner _playerSpawner;
        private DataStore _dataStore;

        private void Awake()
        {
            _dataStore = new PlayerPrefsDataStoreAdapter();
        }

        public void SaveGame()
        {
            var saveData = new SaveData(_enemySpawner.Enemies, _playerSpawner.Player);
            _dataStore.SetData(saveData, "SaveData");
        }

        public void LoadGame()
        {
            var saveData = _dataStore.GetData<SaveData>("SaveData");
            _enemySpawner.Enemies = saveData.Enemies;
            _playerSpawner.Player = saveData.Player;
        }
    }
}
