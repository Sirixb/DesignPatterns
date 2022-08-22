using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField] private GameObject _Panel;
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
            //_Panel.SetActive(isPaused);
            Hide();
            _resumeButton.onClick.AddListener(Resume);
            _restartButton.onClick.AddListener(RestartBattle);
            _menuButton.onClick.AddListener(BackToMenu);
        }

        private void Resume()
        {
            _inGameMenuMediator.OnResumeGamePressed();
            Hide();
            //PauseGame();
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