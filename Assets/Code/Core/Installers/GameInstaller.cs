using Battle;
using Common;
using GameAudio;
using Pickups;
using Patterns.Decoupling.ServiceLocator;
using Ships;
using Ships.Common;
using Ships.Enemies;
using UI;
using UnityEngine;
//using ScoreSystemImpl = Common.ScoreSystemImpl;

namespace Core.Installers
{
    public class GameInstaller : GeneralInstaller
    {

        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private ShipInstaller _shipInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private GameStateController _gameStateController;
        [SerializeField] private ScreenFade _screenFade;

        [SerializeField] private ShipsConfiguration _shipsConfiguration;
        [SerializeField] private ProjectilesConfiguration _projectilesConfiguration;
        [SerializeField] private PickupsConfiguration _pickupsConfiguration;

        private PickupDropper _pickupDropper;

        protected override void DoStart()
        {
            ServiceLocator.Instance.GetService<AudioService>().PlayMusic(AudioIds.GameplayMusic);

            _pickupDropper = new PickupDropper(ServiceLocator.Instance.GetService<PickupFactory>());
            _pickupDropper.Subscribe(ServiceLocator.Instance.GetService<EventQueue>());
        }

        protected override void DoInstallDependencies()
        {
            ServiceLocator.Instance.RegisterService(_scoreView);
            ServiceLocator.Instance.RegisterService(_shipInstaller);
            ServiceLocator.Instance.RegisterService(_enemySpawner);
            ServiceLocator.Instance.RegisterService(_gameStateController);
            ServiceLocator.Instance.RegisterService(_screenFade);

            InstallProjectileFactory();
            InstallPickupFactory();
            InstallShipFactory();
        }

        private void InstallShipFactory()
        {
            var shipFactory = new ShipFactory(Instantiate(_shipsConfiguration));
            ServiceLocator.Instance.RegisterService(shipFactory);
        }

        private void InstallPickupFactory()
        {
            var pickupFactory = new PickupFactory(Instantiate(_pickupsConfiguration));
            ServiceLocator.Instance.RegisterService(pickupFactory);
        }

        private void InstallProjectileFactory()
        {
            var projectileFactory = new ProjectileFactory(Instantiate(_projectilesConfiguration));
            ServiceLocator.Instance.RegisterService(projectileFactory);
        }
        private void OnDestroy()
        {
            if (_pickupDropper != null)
            {
                _pickupDropper.Unsubscribe(ServiceLocator.Instance.GetService<EventQueue>());
            }

            ServiceLocator.Instance.UnregisterService<ScoreView>();
            ServiceLocator.Instance.UnregisterService<ShipInstaller>();
            ServiceLocator.Instance.UnregisterService<EnemySpawner>();
            ServiceLocator.Instance.UnregisterService<GameStateController>();
            ServiceLocator.Instance.UnregisterService<ScreenFade>();
            ServiceLocator.Instance.UnregisterService<ShipFactory>();
            ServiceLocator.Instance.UnregisterService<ProjectileFactory>();
            ServiceLocator.Instance.UnregisterService<PickupFactory>();
        }
    }
}
