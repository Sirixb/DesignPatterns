using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour 
    {
        [SerializeField] private float _speed;
        private Transform _myTransform;
        
        private Ship _ship;
        private CheckLimits _checkLimits;

        private void Awake()
        {
            _myTransform = transform;
        }

        public void Configure(Ship ship, CheckLimits checkLimits)
        {
            _ship = ship;
            _checkLimits = checkLimits;
        }


        public void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            //ClampFinalPosition();
            _checkLimits.ClampFinalPosition();
        }

    }
}
