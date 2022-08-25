using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreEntryView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _positionText;
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void Configure(string position, string score)
        {
            _positionText.SetText(position);
            _scoreText.SetText(score);
        }

    }
}