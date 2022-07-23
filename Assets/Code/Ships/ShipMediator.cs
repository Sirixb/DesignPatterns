using pruebasDavid;
using System;
using UnityEngine;
using Input;
using Ships.CheckLimits;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : MonoBehaviour , Ship
    {
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private MovementController _moveController;

        private Input.Input _input;

        [SerializeField] private ShipId _shipId;
        public string Id => _shipId.Value;

        public void Configure(Input.Input input, CheckLimits.CheckLimits checkLimits,
                              Vector2 speed, float fireRate, ProjectileId defaultProjectileId)
        {
            _input = input;
            _moveController.Configure(this, checkLimits, speed);
            _weaponController.Configure(this, fireRate, defaultProjectileId);
        }
        
        private void Update()
        {
            var direction = _input.GetDirection();
            _moveController.Move(direction);
            TryShoot();
        }

        public void TryShoot()
        {    
            if (_input.IsFireActionPressed())
            {
                _weaponController.TryShoot();
            }
        }
    }
}
