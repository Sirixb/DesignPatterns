using Battle;
using Common;
using Common.Commands;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameMenuView : MonoBehaviour, InGameMenuMediator, EventObserver
    {
        
        
        private bool isPaused = false;

        [SerializeField] private VictoryView _victoryView;
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private PauseView _pauseView;

        private void Awake()
        {
            _victoryView.Configure(this);
            _gameOverView.Configure(this);
            _pauseView.Configure(this);
        }

        private void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.GameOver, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.Victory, this);
        }
        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.GameOver, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.Victory, this);
        }

        public void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                OnPauseGamePressed();
            }
        }

        public void OnBackToMenuPressed()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(new LoadSceneCommand("Menu"));
            if(isPaused)
                OnPauseGamePressed();
        }

        public void OnRestartGamePressed()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                       .AddCommand(new LoadGameSceneCommand());
            if (isPaused) 
                OnPauseGamePressed();
        }

        public void OnResumeGamePressed()
        {
            OnPauseGamePressed();
            _pauseView.Hide();
        }

        public void OnPauseGamePressed()
        {
            isPaused = !isPaused;
            //_Panel.SetActive(isPaused);

            if (isPaused)
            {
                _pauseView.Show();
                Time.timeScale = 0;
            }
            else
            {
                _pauseView.Hide(); 
                Time.timeScale = 1;
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.GameOver)
            {
                _gameOverView.Show();
            }

            if (eventData.EventId == EventIds.Victory)
            {
                _victoryView.Show();
            }
        }
    }
}
