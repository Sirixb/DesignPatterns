using UnityEngine;
using Ships.Weapons;
using System.Linq;
using Ships.Common;

namespace Ships
{
    public class ProjectileFactory 
    {
        private readonly ProjectilesConfiguration _projectileConfiguration;

        public ProjectileFactory(ProjectilesConfiguration Configuration)
        {
            _projectileConfiguration = Configuration;
        }

        public Projectile Create(string id, Vector3 position, Quaternion rotation, Teams team)
        {
            var prefab = _projectileConfiguration.GetProjectileById(id);

            var projectile = Object.Instantiate(prefab,position,rotation);
            projectile.Configure(team);
            
            return projectile;
        }

      


        //Mi Solution Exercise

        //private Transform _projectileSpawnPosition;

        //public ProjectileFactory(ProjectilesConfiguration projectilesConfiguration, Transform projectileSpawn)
        //{
        //    _projectileConfiguration= projectilesConfiguration;
        //    _projectileSpawnPosition = projectileSpawn;
        //}

        //public void Create(string projectileId)
        //{
        //    //var prefab = _projectilePrefabs.First(projectile => projectile.Id.Equals(projectileId));
        //    var prefab =  _projectileConfiguration.GetProjectileById(projectileId);
        //  
        //    Object.Instantiate(prefab, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        //}
    }
}
