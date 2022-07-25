using System.Collections.Generic;
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

        private List<ShipMediator> _spawnedShips;

        private void Awake()
        {
            _spawnedShips = new List<ShipMediator>();
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

            foreach (var shipMediator in _spawnedShips)
            {
                Destroy(shipMediator.gameObject);
            }
            _spawnedShips.Clear();
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
                                  .Build();
                _spawnedShips.Add(ship);
            }
        }


      
    }
}
