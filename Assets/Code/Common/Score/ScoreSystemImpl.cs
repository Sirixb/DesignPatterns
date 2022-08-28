using Core.DataStorage;
using Patterns.Decoupling.ServiceLocator;
using Ships.Common;
using UI;
using UnityEngine;

namespace Common.Score
{
    public class ScoreSystemImpl : EventObserver , ScoreSystem
    {
        public int CurrentScore => _currentScore;

        private readonly DataStore _dataStore;
        private int _currentScore;
        private const string Userdata = "UserData";

        public ScoreSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.Victory, this);
            eventQueue.Subscribe(EventIds.ShipDestroyed, this);
        }

        public void Reset()
        {
            _currentScore = 0;
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.Victory)
            {
                UpdateBestScores(_currentScore);
                return;
            }
            
            if (eventData.EventId == EventIds.ShipDestroyed)
            {
                var shipDestroyedEventData = (ShipDestroyedEventData)eventData;
                AddScore(shipDestroyedEventData);
                return;
            }

        }
        private void AddScore(ShipDestroyedEventData shipDestroyedEventData)
        {
            if (shipDestroyedEventData.Team != Teams.Enemy)
            {
                return;
            }

            _currentScore += shipDestroyedEventData.ScoreToAdd;
            ServiceLocator.Instance.GetService<ScoreView>()
                          .UpdateScore(CurrentScore);
        }

        private void UpdateBestScores(int newScore)
        {
            var bestScores = GetBestScores();
            var scoreIndex = 0;
            for (; scoreIndex < bestScores.Length; ++scoreIndex)
            {
                if (bestScores[scoreIndex] < newScore)
                {
                    break;
                }
            }

            var isTheNewScoreBetter = scoreIndex < bestScores.Length;
            if (!isTheNewScoreBetter)
            {
                return;
            }

            var oldScore = bestScores[scoreIndex];
            bestScores[scoreIndex] = newScore;
            scoreIndex += 1;
            for (; scoreIndex < bestScores.Length; ++scoreIndex)
            {
                newScore = bestScores[scoreIndex];
                bestScores[scoreIndex] = oldScore;
                oldScore = newScore;
            }

            SaveBestScores(bestScores);
        }

        private void SaveBestScores(int[] bestScores)
        {
            var userData = new UserData { BestScores = bestScores };
            _dataStore.SetData(userData, Userdata);
        }

        public int[] GetBestScores()
        {
            var userData = _dataStore.GetData<UserData>(Userdata)
                        ?? new UserData();
            return userData.BestScores;
        }

    }
}
