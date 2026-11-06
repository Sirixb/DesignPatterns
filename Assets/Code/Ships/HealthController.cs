using Ships.Common;
using UnityEngine;

namespace Ships
{
    public class HealthController : MonoBehaviour, Damageable
    {
        public Teams Team { get; private set; }

        private int _health;
        private Ship _ship;

        public void Configure(Ship ship, int health, Teams team)
        {
            _ship = ship;
            _health = health;
            Team = team;
        }
        
        public void AddDamage(int amount)
        {
            // Already dead (and recycled): several colliders can hit in the same physics step.
            if (_health <= 0)
            {
                return;
            }

            _health = Mathf.Max(0, _health - amount);

            var isDeath = _health <= 0;
            _ship.OnDamageReceived(isDeath);

        }

    }
}
