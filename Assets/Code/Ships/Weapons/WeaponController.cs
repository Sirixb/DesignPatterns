using UnityEngine;
using Ships.Weapons;

namespace Ships
{
    public class WeaponController: MonoBehaviour
    {
        [SerializeField] private ProjectilesConfiguration _projectileConfiguration;
        private float _fireRateInSeconds;
        [SerializeField] private Transform _projectileSpawnPosition;
        private float _remainingSecondsToBeAbleToShoot;
        [SerializeField] private ProjectileFactory _projectileFactory;
                                                                                                                         
        private string _activeProjectileId;
        private Ship _ship;


        private void Awake()
        {
            var instance = Instantiate(_projectileConfiguration);
            _projectileFactory = new ProjectileFactory(instance);
        }

        public void Configure(Ship ship, float fireRate, ProjectileId defaultProjectileId)
        {
            _ship = ship;
            _activeProjectileId = defaultProjectileId.Value;
            _fireRateInSeconds = fireRate;

        }

        public void TryShoot()
        {
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
            if (_remainingSecondsToBeAbleToShoot > 0)
            {
                return;
            }

            Shoot();           
        }

        private void Shoot()
        {
            var projectile = _projectileFactory
                .Create(_activeProjectileId, 
                        _projectileSpawnPosition.position, 
                        _projectileSpawnPosition.rotation);
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;           
        }

        //Solution Exercise
        //private void Shoot()
        //{
        //    //var prefab = _projectilePrefabs.First(projectile => projectile.Id.Equals(_activeProjectileId));
        //    _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
        //    //Instantiate(prefab, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);

        //    _projectileFactory.Create(/*_activeProjectileId*/_ProjectileId.Value);
        //}

    }
}
