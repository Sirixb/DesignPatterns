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
        private Dictionary<string, ObjectPool> _pools;

        public ProjectileFactory(ProjectilesConfiguration Configuration)
        {
            _projectileConfiguration = Configuration;

            var projectiles = _projectileConfiguration.ProjectilePrefabs;
            
            _pools = new Dictionary<string, ObjectPool>(projectiles.Length);

            foreach (var projectile in projectiles)
            {
                var objectPool = new ObjectPool(projectile);
                _pools.Add(projectile.Id, objectPool);
                objectPool.Init(10);
            }
        }

        public Projectile Create(string id, Vector3 position, Quaternion rotation, Teams team)
        {

            var projectile = _pools[id].Spawn<Projectile>(position, rotation);
            projectile.Configure(team);

            return projectile;
        }
    }
}
