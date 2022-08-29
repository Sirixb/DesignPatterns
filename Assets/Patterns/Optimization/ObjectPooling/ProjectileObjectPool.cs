using Common.Utils;
using UnityEngine;

namespace Patterns.Optimization.ObjectPooling
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileObjectPool : RecyclableObject
    {
        [SerializeField] protected Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed;

        internal override void Init()
        {
            _rigidbody2D.velocity = transform.up * _speed;
            Invoke(nameof(Recycle), 5);
        }

        internal override void Release()
        {
        }
    }
}
