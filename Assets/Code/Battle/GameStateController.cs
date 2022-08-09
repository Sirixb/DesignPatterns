using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Battle.GameStates;
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

        private void Awake()
        {
            _idToState =
                new Dictionary<GameStates, GameState>
                {
                    {GameStates.Playing, new PlayingState()},
                    {GameStates.GameOver, new GameOverState(_gameFacade)},
                    {GameStates.Victory, new VictoryState(_gameFacade)}
                };
        }

        private void Start()
        {
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
