using Pickups;
using Ships.Weapons;
using UnityEngine;

namespace Ships.Enemies
{
    [CreateAssetMenu(menuName = "Create ShipToSpawnConfiguration", fileName = "ShipToSpawnConfiguration", order = 0)]
    public class ShipToSpawnConfiguration : ScriptableObject
    {
        [SerializeField] private ShipId _shipId;
        [SerializeField] private ProjectileId _defaultProjectileId;
        [SerializeField] private Vector2 _speed;
        [SerializeField] private float _fireRate;
        [SerializeField] private int _health;
        [SerializeField] private int _score;
        [Tooltip("Pickup dropped when this ship is destroyed by the player.")]
        [SerializeField] private PickupIds _drop;

        public ShipId ShipId => _shipId;
        public ProjectileId DefaultProjectileId => _defaultProjectileId;
        public Vector2 Speed => _speed;
        public float FireRate => _fireRate;
        public int Health => _health;
        public int Score  => _score;
        public PickupIds Drop => _drop;

    }
}
