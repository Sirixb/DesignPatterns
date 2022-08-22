using Battle;
using Common;
using Common.Commands;
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

        private void Start()
        {
            Hide();
            //ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.Victory, this);
        }

        private void BackToMenu()
        {
            _inGameMenuMediator.OnBackToMenuPressed();
            //ServiceLocator.Instance.GetService<CommandQueue>()
            //              .AddCommand(new LoadSceneCommand("Menu"));
        }


        //private void OnDestroy()
        //{
        //    //ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.Victory, this);
        //}

        private void RestartGame()
        {
            _inGameMenuMediator.OnRestartGamePressed();
            //ServiceLocator.Instance.GetService<CommandQueue>()
            //              .AddCommand(new StartBattleCommand()); 
            Hide();
        }
        //public void Process(EventData eventData)
        //{
        //    //if (eventData.EventId == EventIds.Victory)
        //    //{
        //    //    _scoreText.SetText(ServiceLocator.Instance.GetService<ScoreView>().CurrentScore.ToString());
        //    //    gameObject.SetActive(true);
        //    //}
        //}

        
        public void Show()
        {
            gameObject.SetActive(true);
            _scoreText.SetText(ServiceLocator.Instance.GetService<ScoreView>().CurrentScore.ToString());
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
