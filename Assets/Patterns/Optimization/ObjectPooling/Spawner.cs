using System;
using UnityEngine;

namespace Patterns.Optimization.ObjectPooling
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private ProjectileObjectPool _prefab;
        private ProjectileProjectileObjectPoolFactory _factory;

        private void Awake()
        {
            _factory = new ProjectileProjectileObjectPoolFactory(_prefab);
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                _factory.Create();
            }
        }
    }
}
