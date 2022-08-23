using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Common;
using Battle;
using Patterns.Decoupling.ServiceLocator;
using Patterns.Behaviour.Command;
using Common.Commands;

namespace UI
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _backToMenuButton;

        private InGameMenuMediator _inGameMenuMediator;

        public void Configure(InGameMenuMediator inGameMenuMediator)
        {
            _inGameMenuMediator = inGameMenuMediator;
        }
        
        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _backToMenuButton.onClick.AddListener(BackToMenu);
        }    

        private void BackToMenu()
        {
            _inGameMenuMediator.OnBackToMenuPressed(); 
        }

        private void RestartGame()
        {
            _inGameMenuMediator.OnRestartGamePressed();
        }

        public void Show()
        {
            _scoreText.SetText(ServiceLocator.Instance.GetService<ScoreView>().CurrentScore.ToString());
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

    }
}
