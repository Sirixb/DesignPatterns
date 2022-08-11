using UnityEngine;

namespace Patterns.Decoupling.ServiceLocator
{
    public class ScoreSystem : IScoreSystem
    {
        private int _currentScore;
        
        public void AddScore(int score)
        {
            _currentScore += score;
            Debug.Log(_currentScore);
        }
    }
}
