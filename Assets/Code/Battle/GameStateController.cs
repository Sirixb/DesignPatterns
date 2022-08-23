using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Battle.GameStates;
using Common.Commands;
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

        private GameState _currentState;

        private Dictionary<GameStates, GameState> _idToState;

        private void Start()
        {
            var stopBattleCommand = new StopBattleCommand();
            _idToState = new Dictionary<GameStates, GameState>
                {
                    {GameStates.Playing, new PlayingState()},
                    {GameStates.GameOver, new GameOverState(stopBattleCommand)},
                    {GameStates.Victory, new VictoryState(stopBattleCommand)}
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
