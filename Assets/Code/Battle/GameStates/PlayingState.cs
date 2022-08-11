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
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.ShipDestroyed, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.ShipSpawned, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.AllShipSpawned, this);

        }

        public void Stop()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.ShipDestroyed, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.ShipSpawned, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.AllShipSpawned, this);

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
