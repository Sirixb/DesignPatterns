using UnityEngine;
using Ships.Weapons;

namespace Ships
{
    public class WeaponController: MonoBehaviour
    {
        [SerializeField] private float _fireRateInSeconds;
        //[SerializeField] private Projectile1[] _projectilePrefabs;
        [SerializeField] private Transform _projectileSpawnPosition;
        private float _remainingSecondsToBeAbleToShoot;

        private string _activeProjectileId;
        private Ship _ship;

        [SerializeField] private ProjectileFactory _projectileFactory;
        [SerializeField] private ProjectileId  _defaultProjectileId;
        //[SerializeField] private ProjectileId _ProjectileId;  //Cambiaba en tiempo de ejecucion
        [SerializeField] private ProjectilesConfiguration _projectileConfiguration;

        private void Awake()
        {
            var instance = Instantiate(_projectileConfiguration);
            _projectileFactory = new ProjectileFactory(instance);
        }

        public void Configure(Ship ship)
        {
            _ship = ship;
            //_activeProjectileId = "Projectile1";
            _activeProjectileId = _defaultProjectileId.Value;

            //_projectileFactory = new ProjectileFactory(Instantiate(_projectileConfiguration),transform);
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
