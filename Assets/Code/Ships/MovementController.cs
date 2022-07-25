using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour
    {
        private Vector2 _speed;
        
        private Ship _ship;
        private Rigidbody2D _rigidbody;
        private CheckLimits.CheckLimits _checkLimits;
        private Vector2 _currentPosition;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _currentPosition = _rigidbody.position;
        }

        public void Configure(Ship ship, CheckLimits.CheckLimits checkLimits, Vector2 speed)
        {
            _ship = ship;
            _checkLimits = checkLimits;
            _speed = speed;
        }
        
        public void Move(Vector2 direction)
        {
            _currentPosition += direction * (_speed * Time.deltaTime);
            _currentPosition = _checkLimits.ClampFinalPosition(_currentPosition);
            _rigidbody.MovePosition(_currentPosition);
        }
    }
}
