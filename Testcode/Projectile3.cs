using System.Collections;
using UnityEngine;

namespace Ships.Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile2 : Projectile
    {
        //[SerializeField] private string _id;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed;

        //public string Id => _id;
      
        private void Start()
        {
            _rigidbody2D.velocity = transform.up * _speed;
            StartCoroutine(DestroyIn(4));
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}
