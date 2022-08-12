using System;
using Common;
using Patterns.Decoupling.ServiceLocator;

namespace Battle.GameStates
{
    public class VictoryState : GameState
    {
        private readonly GameFacade _gameFacade;

        public VictoryState(GameFacade gameFacade)
        {
            _gameFacade = gameFacade;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
           _gameFacade.StopBattle();
           ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.Victory));
        }

        public void Stop()
        {
        }
    }
}
