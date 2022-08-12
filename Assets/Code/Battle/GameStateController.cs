using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Battle.GameStates;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;

namespace Battle
{
    public class GameStateController : MonoBehaviour
    {
        public enum GameStates
        {
            Playing,
            GameOver,
            Victory
        }

        [SerializeField] private GameFacade _gameFacade;

        private GameState _currentState;

        private Dictionary<GameStates, GameState> _idToState;

        private void Start()
        {
            var gameFacade = ServiceLocator.Instance.GetService<GameFacade>();
            _idToState =
                new Dictionary<GameStates, GameState>
                {
                    {GameStates.Playing, new PlayingState()},
                    {GameStates.GameOver, new GameOverState(gameFacade)},
                    {GameStates.Victory, new VictoryState(gameFacade)}
                };

            _currentState = GetState(GameStates.Playing);
            _currentState.Start(ChangeToNextState);
        }

        private async void ChangeToNextState(GameStates nextState)
        {
            await Task.Yield(); 
            _currentState.Stop();
            _currentState = GetState(nextState);
            _currentState.Start(ChangeToNextState);
        }

        public void Reset()
        {
            ChangeToNextState(GameStates.Playing);
        }

        private GameState GetState(GameStates state)
        {
            return _idToState[state];
        }

    }
}
