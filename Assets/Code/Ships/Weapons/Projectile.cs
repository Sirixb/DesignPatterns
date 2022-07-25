using System;
using System.Collections;
using UnityEngine;

namespace Ships
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour
    {
        
        [SerializeField] private ProjectileId _projectileId;
        public string Id => _projectileId.Value;

        [SerializeField] protected Rigidbody2D _rigidbody2D;
        [SerializeField] protected float _speed;

        protected Transform _myTransform;

        private void Start()
        {
            _myTransform = transform; 
            StartCoroutine(DestroyIn(4));
            DoStart();
        }

        protected abstract void DoStart();

        public void FixedUpdate()
        {
            DoMove();
        }

        protected abstract void DoMove();

        public void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Projectile collided: " + collision.name);
            DestroyProjectile();
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            DestroyProjectile();
        }

        private void DestroyProjectile()
        {
            DoDestroy();
            Destroy(gameObject);
        }


        protected abstract void DoDestroy();
       

    }
}
