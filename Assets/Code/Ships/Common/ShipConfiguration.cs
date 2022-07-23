using Ships.Weapons;
using UnityEngine;

namespace Ships.Common
{
    public class ShipConfiguration
    {
        public readonly Input.Input Input;
        public readonly CheckLimits.CheckLimits CheckLimits;

        public readonly Vector2 Speed;
        public readonly float FireRate;
        public readonly ProjectileId DefaultProjectileId;

        public ShipConfiguration(Input.Input input, CheckLimits.CheckLimits checkLimits,
                                 Vector2 speed, float fireRate,
                                 ProjectileId defaultProjectileId)
        {
            Input = input;
            CheckLimits = checkLimits;
            Speed = speed;
            FireRate = fireRate;
            DefaultProjectileId = defaultProjectileId;
        }
    }
}
