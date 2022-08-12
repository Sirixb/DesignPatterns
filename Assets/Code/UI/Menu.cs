using System;
using Battle;
using Patterns.Decoupling.ServiceLocator;
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

        //[SerializeField] private GameFacade _gameFacade;

        private void Awake()
        {
            _startBattleButton.onClick.AddListener(StartBattle);
            _stopBattleButton.onClick.AddListener(StopBattle);
        }

        private void StartBattle()
        {
            ServiceLocator.Instance.GetService<GameFacade>().StartBattle();
        }

        private void StopBattle()
        {
            ServiceLocator.Instance.GetService<GameFacade>().StopBattle();
        }
    }
}
