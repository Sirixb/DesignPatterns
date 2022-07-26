using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
            gameObject.SetActive(false);
        }

        private void RestartGame()
        {
            // StartBattle
            // gameObject.SetActive(false);
        }

        public void Show()
        {
            // Stop Battle
            // Set score
            // gameObject.SetActive(true);
        }
    }
}
