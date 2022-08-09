using System;

namespace Battle.GameStates
{
    public interface GameState
    {
        void Start(Action<GameStateController.GameStates> onEndedCallback);
        void Stop();
    }
}
