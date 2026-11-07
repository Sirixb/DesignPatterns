using Battle;
using Common;
using Common.Commands;
using GameAudio;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameMenuView : MonoBehaviour, InGameMenuMediator, EventObserver
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private PauseMenuView _pauseMenuView;
        [SerializeField] private VictoryView _victoryView;
        [SerializeField] private GameOverView _gameOverView;
        private CommandQueue _commandQueue;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonPressed);
            _victoryView.Configure(this);
            _gameOverView.Configure(this);
            _pauseMenuView.Configure(this);
        }

        private void Start()
        {
            _commandQueue = ServiceLocator.Instance.GetService<CommandQueue>(); 
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.GameOver, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.Victory, this);
            HideAllMenus();
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.GameOver, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.Victory, this);
        }

        private void HideAllMenus()
        {
            _pauseMenuView.Hide();
            _victoryView.Hide();
            _gameOverView.Hide();
        }
      
        private static void PlaySound(AudioIds id)
        {
            ServiceLocator.Instance.GetService<AudioService>().PlaySfx(id);
        }

        private void OnPauseButtonPressed()
        {
            PlaySound(AudioIds.ButtonClick);
            _commandQueue.AddCommand(new PauseGameCommand());
            _pauseMenuView.Show(); 
        }

        public void OnBackToMenuPressed()
        {
            PlaySound(AudioIds.ButtonClick);
            _commandQueue.AddCommand(new LoadSceneCommand("Menu"));
            ResumeGame();
        }

        public void OnResumeGamePressed()
        {
            PlaySound(AudioIds.ButtonClick);
            _pauseMenuView.Hide();
            ResumeGame();
        } 

        public void OnRestartGamePressed()
        {
            PlaySound(AudioIds.ButtonConfirm);
            HideAllMenus();
            ResumeGame();
            _commandQueue.AddCommand(new RestartBattleCommand());
        }

        private void ResumeGame()
        {
            _commandQueue.AddCommand(new ResumeGameCommand());
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.Victory)
            {
                _victoryView.Show();
                return;
            }

            if (eventData.EventId == EventIds.GameOver)
            {
                _gameOverView.Show();
                return;
            }

        }
    }
}
