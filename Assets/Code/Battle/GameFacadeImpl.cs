using Patterns.Decoupling.ServiceLocator;
using Ships;
using Ships.Enemies;
using UI;
using UnityEngine;

namespace Battle
{
    public class GameFacadeImpl : MonoBehaviour, GameFacade
    {
        [SerializeField] private ShipInstaller _shipInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private GameStateController _gameStateController;

        public void StartBattle()
        {
            _gameStateController.Reset();
            ScoreView.Instance.Reset();
            _enemySpawner.StartSpawn();
            _shipInstaller.SpawnUserShip();
            ServiceLocator.Instance.GetService<LoadingScreen>().Hide();
        }

        public void StopBattle()
        {
            ServiceLocator.Instance.GetService<LoadingScreen>().Show();
            _enemySpawner.StopAndReset();
        }
    }
}
