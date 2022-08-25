using Ships.Common;
using TMPro;
using UnityEngine;
using Common;
using Patterns.Decoupling.ServiceLocator;

namespace UI
{
    
    public class ScoreView : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _text;

        
        public void Reset()
        {
            UpdateScore(0);
        }

        public void UpdateScore(int newScore)
        {
            _text.SetText(newScore.ToString());
        }
    }
}
