using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Patterns.Adapter
{
    public class Consumer : MonoBehaviour
    {
        private DataStore _dataStore;

        private void Awake()
        {
            _dataStore = GetDataStore();

            var data = new Data("Dato1", 123);
            _dataStore.SetData(data, "Data1");
        }

        private DataStore GetDataStore()
        {
            return new FileDataStoreAdapter();
        }

        private void Start()
        {
            var data = _dataStore.GetData<Data>("Data1");
            Debug.Log(data.Dato1);
            Debug.Log(data.Dato2);
        }
    }
}
