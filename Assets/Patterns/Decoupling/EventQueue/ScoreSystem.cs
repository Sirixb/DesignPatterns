using UnityEngine;

namespace Patterns.Decoupling.EventQueue
{
    public class ScoreSystem
    {
        public static ScoreSystem Instance => _instance ?? (_instance = new ScoreSystem());
        private static ScoreSystem _instance;

        private ScoreSystem()
        {
        }

        public void AddScore(int scoreToAdd)
        {
            Debug.Log("Score added");
        }
    }
}
