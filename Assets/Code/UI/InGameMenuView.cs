using Battle;
using Common.Commands;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameMenuView : MonoBehaviour, InGameMenuMediator
    {
        [SerializeField] private GameObject _Panel;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;
        private bool isPaused = false;

        [SerializeField] private VictoryView victoryView;
        [SerializeField] private GameOverView victoryView;
        [SerializeField] private PauseView victoryView;

        private void Awake()
        {
            _Panel.SetActive(isPaused);
            _resumeButton.onClick.AddListener(Resume);
            _restartButton.onClick.AddListener(RestartBattle);
            _menuButton.onClick.AddListener(BackToMenu);


        }

        public void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }

        private void Resume()
        {
            PauseGame();
        }

        private void RestartBattle()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                       .AddCommand(new LoadGameSceneCommand());
            PauseGame();
        }
        private void BackToMenu()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(new LoadSceneCommand("Menu"));
            PauseGame();
        }


        private void PauseGame()
        {
            isPaused = !isPaused;
            _Panel.SetActive(isPaused);

            if (isPaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        public void OnBackToMenuPressed()
        {
            throw new System.NotImplementedException();
        }

        public void OnRestartGamePressed()
        {
            throw new System.NotImplementedException();
        }

        public void OnResumeGamePressed()
        {
            throw new System.NotImplementedException();
        }

        public void OnPauseGamePressed()
        {
            throw new System.NotImplementedException();
        }
    }
}
