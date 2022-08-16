using Battle;
using Common.Commands;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button _startBattleButton;
        [SerializeField] private Button _stopBattleButton;

        private void Awake()
        {
            _startBattleButton.onClick.AddListener(StartBattle);
            _stopBattleButton.onClick.AddListener(StopBattle);
        }

        private void StartBattle()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(new StartBattleCommand());
        }

        private void StopBattle()
        {
            ServiceLocator.Instance.GetService<GameFacade>().StopBattle();
        }
    }
}
