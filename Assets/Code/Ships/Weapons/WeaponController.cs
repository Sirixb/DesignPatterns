using UnityEngine;
using Ships.Common;
using System.Collections.Generic;
using Patterns.Decoupling.ServiceLocator;
using GameAudio;

namespace Ships
{
    public class WeaponController: MonoBehaviour
    {
        private const float MinFireRateInSeconds = 0.05f;

        private float _fireRateInSeconds;
        [SerializeField] private Transform _projectileSpawnPosition;
        private float _remainingSecondsToBeAbleToShoot;
        [SerializeField] private ProjectileFactory _projectileFactory;
                                                                                                                         
        private AudioService _audioService;
        private string _activeProjectileId;
        private Ship _ship;
        private Teams _team;

        private List<Projectile> _aliveProjectiles;

        private void Awake()
        {
            _aliveProjectiles = new List<Projectile>();
        }
        private void Start()
        {
            _projectileFactory = ServiceLocator.Instance.GetService<ProjectileFactory>();
            _audioService = ServiceLocator.Instance.GetService<AudioService>();
        }

        public void Configure(Ship ship, float fireRate, ProjectileId defaultProjectileId, Teams team)
        {
            _ship = ship;
            _activeProjectileId = defaultProjectileId.Value;
            _fireRateInSeconds = fireRate;
            _team = team;
        }

        public void MultiplyFireRate(float factor)
        {
            _fireRateInSeconds = Mathf.Max(MinFireRateInSeconds, _fireRateInSeconds * factor);
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
                        _projectileSpawnPosition.rotation,
                        _team
                        );
            _aliveProjectiles.Add(projectile);
            projectile.OnRecycle += OnProjectileDestroy;
            _audioService.PlaySfx(_team == Teams.Ally ? AudioIds.PlayerShot : AudioIds.EnemyShot);
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;           
        }

        private void OnProjectileDestroy(Projectile projectile)
        {
            _aliveProjectiles.Remove(projectile);
            projectile.OnRecycle -= OnProjectileDestroy;
        }

        public void Restart()
        {
            foreach (var aliveProjectile in _aliveProjectiles)
            {
                aliveProjectile.Recycle();
            }

            _aliveProjectiles.Clear();
        }
    }
}
