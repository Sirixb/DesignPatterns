using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ships
{
    [CreateAssetMenu(menuName = "Weapons/Create ProjectilesConfiguration", fileName = "ProjectilesConfiguration", order = 0)]
    public class ProjectilesConfiguration : ScriptableObject
    {
        [SerializeField] public Projectile[] _projectilePrefabs;
        private Dictionary<string, Projectile> _idToProjectilesPrefabs;

        private void Awake()
        {
            _idToProjectilesPrefabs = new Dictionary<string, Projectile>();
            foreach (var projectile in _projectilePrefabs)
            {
                _idToProjectilesPrefabs.Add(projectile.Id, projectile);
            }
        }

        public Projectile GetProjectileById(string id)
        {
            //var prefab = _projectilePrefabs.First(projectile => projectile.Id.Equals(projectileId));
            //return _idToProjectilesPrefabs[id];
            if (!_idToProjectilesPrefabs.TryGetValue(id,out var projectile))
            {
                throw new Exception($"Projectile {id} not found");
            }
            return projectile;
        }
    }
}
