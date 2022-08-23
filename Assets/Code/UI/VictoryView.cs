using Battle;
using Common;
using Common.Commands;
using Core.DataStorage;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class VictoryView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private UserData _userData;

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
