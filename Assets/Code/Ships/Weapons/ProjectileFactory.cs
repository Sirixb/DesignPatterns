using UnityEngine;
using Ships.Common;
using Patterns.Optimization.ObjectPooling;
using System.Collections.Generic;
using System;

namespace Ships
{
    public class ProjectileFactory 
    {
        private readonly ProjectilesConfiguration _projectileConfiguration;
        private Dictionary<string, ObjectPool> _objectPools = new Dictionary<string, ObjectPool>();

        public ProjectileFactory(ProjectilesConfiguration Configuration)
        {
            _projectileConfiguration = Configuration;

            var projectiles = _projectileConfiguration.GetAllPrefabs();

            for (int i = 0; i < projectiles.Length; i++)
            {
                _objectPools.Add(projectiles[i].Id, new ObjectPool(projectiles[i]));
            }

            foreach (var pool in _objectPools.Values)
            {
                pool.Init(0);
            }
        }

        public Projectile Create(string id, Vector3 position, Quaternion rotation, Teams team)
        {
      
            //var prefab = _projectileConfiguration.GetProjectileById(id);

            var pool = GetPool(id);

            var projectile = pool.Spawn<Projectile>(position, rotation);
            projectile.Configure(team);

            return projectile;
        }

        public ObjectPool GetPool(string id)
        {
            if (!_objectPools.TryGetValue(id, out var pool))
            {
                throw new Exception($"Pool {id} not found");
            }
            return pool;
        }
       
        //public ProjectileFactory(ProjectilesConfiguration Configuration)
        //{
        //    _projectileConfiguration = Configuration;
        //}
        //public Projectile Create(string id, Vector3 position, Quaternion rotation, Teams team)
        //{
        //    var prefab = _projectileConfiguration.GetProjectileById(id);

        //    var projectile = Object.Instantiate(prefab,position,rotation);
        //    projectile.Configure(team);

        //    return projectile;
        //}
    }
}
