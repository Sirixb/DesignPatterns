using System;
using Common;
using Patterns.Decoupling.ServiceLocator;
using Ships.Common;

namespace Battle.GameStates
{
    public class PlayingState : GameState, EventObserver
    {
        private Action<GameStateController.GameStates> _onEndedCallback;
        private int _aliveShips;
        private bool _allShipSpawned;

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            _onEndedCallback = onEndedCallback;
            _aliveShips = 0;
            _allShipSpawned = false;
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.ShipDestroyed, this);
            eventQueue.Subscribe(EventIds.ShipSpawned, this);
            eventQueue.Subscribe(EventIds.AllShipSpawned, this); 
        }

        public void Stop()
        {
           var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.ShipDestroyed, this);
            eventQueue.Unsubscribe(EventIds.ShipSpawned, this);
            eventQueue.Unsubscribe(EventIds.AllShipSpawned, this);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ShipDestroyed)
            {
                _aliveShips -= 1;
                var shipDestroyedEventData = (ShipDestroyedEventData)eventData;
                if (shipDestroyedEventData.Team == Teams.Ally)
                {
                    _onEndedCallback?.Invoke(GameStateController.GameStates.GameOver);
                    return;
                }
            }
            else if (eventData.EventId == EventIds.ShipSpawned)
            {
                _aliveShips += 1;
            }
            else if (eventData.EventId == EventIds.AllShipSpawned)
            {
                _allShipSpawned = true;
            }

            CheckGameState();
        }

        private void CheckGameState()
        {
            if (_aliveShips == 0 && _allShipSpawned)
            {
                _onEndedCallback?.Invoke(GameStateController.GameStates.Victory);
            }
        }
    }
}
