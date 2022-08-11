using TMPro;
using UnityEngine;

namespace Patterns.Decoupling.ServiceLocator
{
    public class ScoreSystemMonoBehaviour2 : MonoBehaviour, IScoreSystem
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        private int _currentScore;

        public void AddScore(int score)
        {
            _currentScore += score;
            Debug.Log(_currentScore);
            _text.SetText(_currentScore.ToString());
        }
    }
}
