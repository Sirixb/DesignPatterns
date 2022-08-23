using System;
using Common;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;

namespace Battle.GameStates
{
    public class VictoryState : GameState
    {
        private readonly Command _stopBattleCommand;

        public VictoryState(Command stopBatleCommand)
        {
            _stopBattleCommand = stopBatleCommand;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(_stopBattleCommand);
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.Victory));
        }

        public void Stop()
        {
        }
    }
}
