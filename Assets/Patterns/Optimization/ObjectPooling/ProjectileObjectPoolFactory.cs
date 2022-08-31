using UnityEngine;

namespace Patterns.Optimization.ObjectPooling
{
    public class ProjectileObjectPoolFactory
    {
        private readonly ProjectileObjectPool _prefab;
        private readonly ObjectPool _objectPool;

        public ProjectileObjectPoolFactory(ProjectileObjectPool prefab)
        {
            _prefab = prefab;
            _objectPool = new ObjectPool(_prefab);
            _objectPool.Init(0);
        }

        public ProjectileObjectPool Create()
        {
            return _objectPool.Spawn<ProjectileObjectPool>(Vector3.one, Quaternion.identity);
        }
    }
}
