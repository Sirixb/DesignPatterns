using System.Collections.Generic;
using Common;
using Patterns.Decoupling.ServiceLocator;
using Ships.Common;
using UnityEngine;

namespace Ships.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private LevelConfiguration _levelConfiguration;
        [SerializeField] private ShipsConfiguration _shipsConfiguration;
        private ShipFactory _shipFactory;

        private float _currentTimeInSeconds;
        private int _currentConfigurationIndex;
        private bool _canSpawn;

        private void Awake()
        {
            _shipFactory = new ShipFactory(Instantiate(_shipsConfiguration));
        }

        public void StartSpawn()
        {
            _canSpawn = true;
        }
        
        public void StopAndReset()
        {
            _canSpawn = false;
            _currentTimeInSeconds = 0f;
            _currentConfigurationIndex = 0;

        }
        
        private void Update()
        {
            if (!_canSpawn)
            {
                return;
            }
            
            if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
            {
                return;
            }

            _currentTimeInSeconds += Time.deltaTime;

            var spawnConfiguration = _levelConfiguration.SpawnConfigurations[_currentConfigurationIndex];
            if (spawnConfiguration.TimeToSpawn > _currentTimeInSeconds)
            {
                return;
            }

            SpawnShips(spawnConfiguration);
            _currentConfigurationIndex += 1;
            
            if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
            {
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.AllShipSpawned));
            }
        }

        private void SpawnShips(SpawnConfiguration spawnConfiguration)
        {
            for (var i = 0; i < spawnConfiguration.ShipToSpawnConfigurations.Length; i++)
            {
                var shipConfiguration = spawnConfiguration.ShipToSpawnConfigurations[i];
                var spawnPosition = _spawnPositions[i % _spawnPositions.Length];
                var shipBuilder = _shipFactory.Create(shipConfiguration.ShipId.Value);
                var ship = shipBuilder
                                  .WithPosition(spawnPosition.position)
                                  .WithRotation(spawnPosition.rotation)
                                  .WithInputMode(ShipBuilder.InputMode.Ai)
                                  .WithCheckLimitType(ShipBuilder.CheckLimitTypes.InitialPosition)
                                  .WithConfiguration(shipConfiguration)
                                  .WithTeam(Teams.Enemy)
                                  .WithCheckDestroyLimits()
                                  .Build();
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.ShipSpawned));
            }
        }

    }
}
