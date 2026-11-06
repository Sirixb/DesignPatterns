using Patterns.Optimization.ObjectPooling;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Common
{
    public class ShipFactory
    {
        private readonly ShipsConfiguration _configuration;
        private Dictionary<string, ObjectPool> _pools;

        public ShipFactory(ShipsConfiguration configuration)
        {
            _configuration = configuration;

            var prefabs = _configuration.shipPrefabs;
            _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

            foreach (var shipMediator in prefabs)
            {
                var objectPool = new ObjectPool(shipMediator);
                _pools.Add(shipMediator.Id, objectPool);
                objectPool.Init(_configuration.InitialPoolSize);
            }

        }

        public ShipBuilder Create(string id)
        {
            var objectPool = _pools[id];

            return new ShipBuilder()
               .FromObjectPool(objectPool);
        }
    }
}
