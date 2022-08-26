using Common.Commands;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuView : MonoBehaviour , MainMenuMediator
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _showLeaderBoardButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private LeaderBoardView _leaderBoardView;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(OnStartButtonPressed);
            _showLeaderBoardButton.onClick.AddListener(OnShowLeaderBoardPressed);
            _quitButton.onClick.AddListener(OnquitPressed);
        }

        private void OnquitPressed()
        {
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
		            Application.Quit();
            #endif  
        }

        private void Start()
        {
            _leaderBoardView.Configure(this);
            //_leaderBoardView.Hide();
        }

        public void OnStartButtonPressed()
        {
            //Solucion profe, yo la hice directamente en el LoadGameSceneCommand
            /*var compositeCommand = new CompositeCommand();
            compositeCommand.AddCommand(new LoadSceneCommand("Game"));
            compositeCommand.AddCommand(new StartBattleCommand());*/
            
            ServiceLocator.Instance.GetService<CommandQueue>()
                         .AddCommand(/*compositeCommand*/ new LoadGameSceneCommand());

        }

        private void OnShowLeaderBoardPressed()
        {
            _leaderBoardView.Show();
        }

        public void OnCloseLeaderBoardPressed()
        {
            _leaderBoardView.Hide();
        }
    }
}
