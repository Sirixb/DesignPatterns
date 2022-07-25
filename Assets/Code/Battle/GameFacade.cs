using Ships.Enemies;
using UI;
using UnityEngine;

namespace Ships
{
    public class GameFacade : MonoBehaviour
    {
        [SerializeField] private ScreenFade _screenFade;
        [SerializeField] private ShipInstaller _shipInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;

     
        public void StartBattle()
        {
            _enemySpawner.StartSpawn();
            _shipInstaller.SpawnUserShip();
            _screenFade.Hide();
        }

        public void StopBattle()
        {
            _screenFade.Show();
            _enemySpawner.StopAndReset();
            _shipInstaller.DestroyUserShip();
        }
    }
}
