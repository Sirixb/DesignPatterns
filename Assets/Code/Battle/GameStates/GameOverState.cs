using System;
using Common;
using Common.Commands;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;

namespace Battle.GameStates
{
    public class GameOverState : GameState
    {
        private readonly Command _stopBattleCommand;

        public GameOverState(Command stopBatleCommand)
        {
            _stopBattleCommand = stopBatleCommand;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(_stopBattleCommand);
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.GameOver));
        }

        public void Stop()
        {
        }
    }
}
