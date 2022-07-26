using UnityEngine;

namespace Patterns.Singleton
{
    public class ScoreSystem
    {
        public static ScoreSystem Instance => _instance ?? (_instance = new ScoreSystem());
        private static ScoreSystem _instance;
        
        private int _currentScore;

        private ScoreSystem()
        {
        }

        public void AddScore(int score)
        {
            _currentScore += score;
            Debug.Log(_currentScore);
        }

        //reemplazado en una linea arriba
        //public static ScoreSystem Instance()
        //{
        //    if(_instance == null)
        //    {
        //        _instance = new ScoreSystem();
        //    }
        //    return _instance;
        //}
    }
}
