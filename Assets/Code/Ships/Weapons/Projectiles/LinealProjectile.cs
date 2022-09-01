using System.Collections;
using UnityEngine;

namespace Ships.Weapons
{   
    public class LinealProjectile : Projectile
    {
        protected override void DoStart()
        {
            _rigidbody2D.velocity = transform.up * _speed;
        }

        protected override void DoMove()
        {
            
        }

    }
}
