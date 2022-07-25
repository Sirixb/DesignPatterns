using System;
using Ships;
using Ships.Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button _startBattleButton;
        [SerializeField] private Button _stopBattleButton;

        [SerializeField] private ScreenFade _screenFade;
        [SerializeField] private ShipInstaller _shipInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;

        private void Awake()
        {
            _startBattleButton.onClick.AddListener(StartBattle);
            _stopBattleButton.onClick.AddListener(StopBattle);
        }

        private void StartBattle()
        {
            _enemySpawner.StartSpawn();
            _shipInstaller.SpawnUserShip();
            _screenFade.Hide();
        }

        private void StopBattle()
        {
            _screenFade.Show();
            _enemySpawner.StopAndReset();
            _shipInstaller.DestroyUserShip();
        }
    }
}
