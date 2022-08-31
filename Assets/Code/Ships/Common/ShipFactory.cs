using Patterns.Optimization.ObjectPooling;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Common
{
    public class ShipFactory
    {
        private readonly ShipsConfiguration _configuration;
        private Dictionary<string, ObjectPool> _objectPools = new Dictionary<string, ObjectPool>();

        public ShipFactory(ShipsConfiguration configuration)
        {
            _configuration = configuration;


            var shipMediators = _configuration.GetAllPrefabs();

            for (int i = 0; i < shipMediators.Length; i++)
            {
                _objectPools.Add(shipMediators[i].Id, new ObjectPool(shipMediators[i]));
            }

            //foreach (var pool in _objectPools.Values)
            //{
            //    pool.Init(2);
            //}
           
        }

        public ShipBuilder Create(string id)
        {
            var prefab = _configuration.GetShipById(id);

            var pool = GetPool(id);

            return new ShipBuilder()
               //.FromObjectPool(pool);
               .FromPrefab(prefab);
        }

        public ObjectPool GetPool(string id)
        {
            if (!_objectPools.TryGetValue(id, out var pool))
            {
                throw new Exception($"Pool {id} not found");
            }
            return pool;
        }

        //public ShipBuilder Create(string id)
        //{
        //    var prefab = _configuration.GetShipById(id);

        //    return new ShipBuilder()
        //       .FromPrefab(prefab);
        //}
    }
}
