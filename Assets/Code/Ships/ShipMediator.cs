using pruebasDavid;
using System;
using UnityEngine;
using Input;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : MonoBehaviour , Ship
    {
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private MovementController _moveController;

        private Input.Input _input;
       
        public void Configure(Input.Input input, CheckLimits checkLimits)
        {
            _input = input;
            _moveController.Configure(this, checkLimits);
            _weaponController.Configure(this);
        }
        
        private void Update()
        {
            var direction = _input.GetDirection();
            Movement(direction);
            TryShoot();
        }

        public void TryShoot()
        {    
            if (_input.IsFireActionPressed())
            {
                _weaponController.TryShoot();
            }
        }

        public void Movement(Vector2 direction)
        {
            _moveController.Move(direction);
        }
    }
}
