using Ships.Common;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        public static ScoreView Instance { get; private set; }

        [SerializeField] private TextMeshProUGUI _text;

        private int _currentScore;
        private int CurrentScore
        {
            get => _currentScore;
            set
            {
                _currentScore = value;
                _text.SetText(_currentScore.ToString());
            }
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }


        public void Reset()
        {
            CurrentScore = 0;
        }
        
        public void AddScore(Teams killedTeam, int scoreToAdd)
        {
            if (killedTeam != Teams.Enemy)
            {
                return;
            }

            CurrentScore += scoreToAdd;
            _text.SetText(CurrentScore.ToString());
        }
    }
}
