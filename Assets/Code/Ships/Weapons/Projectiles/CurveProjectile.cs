using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class CurveProjectile : Projectile
    {
        [SerializeField] private AnimationCurve _horizontalPosition;
        
        private float _currentTime;
        private Vector3 _currentPosition;
      

        protected override void DoStart()
        {
            _currentTime = 0;
            _currentPosition = _myTransform.position;
        }
       
        protected override void DoMove()
        {
            _currentPosition += _myTransform.up * (_speed * Time.deltaTime);
            var horizontalPosition = _myTransform.right * _horizontalPosition.Evaluate(_currentTime);

            _rigidbody2D.MovePosition(_currentPosition + horizontalPosition);

            _currentTime += Time.deltaTime;
        }

      

    }
}
