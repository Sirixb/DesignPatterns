using System;
using System.Collections;
using UnityEngine;
using Ships.Common;
using Patterns.Optimization.ObjectPooling;

namespace Ships
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : RecyclableObject, Damageable
    {
        [SerializeField] protected Rigidbody2D _rigidbody2D;
        [SerializeField] private ProjectileId _projectileId;
        [SerializeField] protected float _speed;
       
        public Teams Team { get; private set; }

        protected Transform _myTransform;
        private bool _isAlive;

        public Action<Projectile> OnRecycle; 
        public string Id => _projectileId.Value;

        public void Configure(Teams team)
        {
            Team = team;
        }

        private void Awake()
        {
            _myTransform = transform;
        }
        
        internal override void Init()
        {
            _isAlive = true;
            DoStart();
            StartCoroutine(RecycleIn(5));
        }

        protected abstract void DoStart();

        public void FixedUpdate()
        {
            DoMove();
        }

        protected abstract void DoMove();

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent<Damageable>(out var damageable))
            {
                return;
            }

            if (damageable.Team == Team)
            {
                return;
            }

            damageable.AddDamage(1);
            //Debug.Log("Projectile collided: " + collision.name);
        }

        private IEnumerator RecycleIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            DestroyProjectile();
        }

        private void DestroyProjectile()
        {
            // Several collisions in the same physics step can try to destroy it twice.
            if (!_isAlive)
            {
                return;
            }

            _isAlive = false;
            Recycle();
            OnRecycle?.Invoke(this);
        }

        internal override void Release()
        {
            
        }


        public void AddDamage(int amount)
        {
            DestroyProjectile();
        }
    }
}
