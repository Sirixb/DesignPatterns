using Ships.Weapons;
using UnityEngine;

namespace Ships.Common
{
    public class ShipConfiguration
    {
        public readonly Input.Input Input;
        public readonly CheckLimits.CheckLimits CheckLimits;

        public readonly Vector2 Speed;
        public readonly int Health;
        public readonly float FireRate;
        public readonly ProjectileId DefaultProjectileId;
        public readonly Teams Team;

        public ShipConfiguration(Input.Input input, CheckLimits.CheckLimits checkLimits,
                                 Vector2 speed, int health, float fireRate,
                                 ProjectileId defaultProjectileId,Teams team)
        {
            Input = input;
            CheckLimits = checkLimits;
            Speed = speed;
            Health = health;
            FireRate = fireRate;
            DefaultProjectileId = defaultProjectileId;
            Team = team;
        }
    }
}
