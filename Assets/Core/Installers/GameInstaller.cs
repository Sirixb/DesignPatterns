using Battle;
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

        protected override void DoStart()
        {
        }

        protected override void DoInstallDependencies()
        {
            ServiceLocator.Instance.RegisterService(_scoreView);
            ServiceLocator.Instance.RegisterService(_shipInstaller);
            ServiceLocator.Instance.RegisterService(_enemySpawner);
            ServiceLocator.Instance.RegisterService(_gameStateController);
            ServiceLocator.Instance.RegisterService(_screenFade);

            InstallShipFactory();
            InstallProjectileFactory();
        }

        private void InstallShipFactory()
        {
            var shipFactory = new ShipFactory(Instantiate(_shipsConfiguration));
            ServiceLocator.Instance.RegisterService(shipFactory);
        }

        private void InstallProjectileFactory()
        {
            var projectileFactory = new ProjectileFactory(Instantiate(_projectilesConfiguration));
            ServiceLocator.Instance.RegisterService(projectileFactory);
        }
        private void OnDestroy()
        {
            ServiceLocator.Instance.UnregisterService<ScoreView>();
            ServiceLocator.Instance.UnregisterService<ShipInstaller>();
            ServiceLocator.Instance.UnregisterService<EnemySpawner>();
            ServiceLocator.Instance.UnregisterService<GameStateController>();
            ServiceLocator.Instance.UnregisterService<ScreenFade>();
            ServiceLocator.Instance.UnregisterService<ShipFactory>();
            ServiceLocator.Instance.UnregisterService<ProjectileFactory>();
        }
    }
}
