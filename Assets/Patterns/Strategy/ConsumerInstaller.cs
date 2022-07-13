using Patterns.Adapter;
using UnityEngine;

namespace Patterns.Strategy
{
    public class ConsumerInstaller : MonoBehaviour
    {
        private void Awake()
        {
            var consumer = new Consumer(GetDataStore());
            consumer.Save();
            consumer.Load();
        }

        private DataStore GetDataStore()
        {
            var isEven = Random.Range(0, 99) % 2 == 0;
            if (isEven)
            {
                return new PlayerPrefsDataStoreAdapter();
            }

            return new FileDataStoreAdapter();
        }
    }
}
