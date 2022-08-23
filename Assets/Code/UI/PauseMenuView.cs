using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseMenuView : MonoBehaviour
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton; 
        
        private InGameMenuMediator _inGameMenuMediator;

        public void Configure(InGameMenuMediator inGameMenuMediator)
        {
            _inGameMenuMediator = inGameMenuMediator;
        }

        private void Awake()
        {
            _resumeButton.onClick.AddListener(Resume);
            _restartButton.onClick.AddListener(RestartBattle);
            _menuButton.onClick.AddListener(BackToMenu);
        }

        private void Resume()
        {
            _inGameMenuMediator.OnResumeGamePressed();
        }

        private void RestartBattle()
        {
            _inGameMenuMediator.OnRestartGamePressed();
        }

        private void BackToMenu()
        {
            _inGameMenuMediator.OnBackToMenuPressed();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

    }
}