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
    public class VictoryView : MonoBehaviour, EventObserver
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _backToMenuButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame); 
            _backToMenuButton.onClick.AddListener(BackToMenu);
        }

        private void BackToMenu()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(new LoadSceneCommand("Menu"));
        }

        private void Start()
        {
            gameObject.SetActive(false);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.Victory, this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.Victory, this);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.Victory)
            {
                _scoreText.SetText(ServiceLocator.Instance.GetService<ScoreView>().CurrentScore.ToString());
                gameObject.SetActive(true);
            }
        }

        private void RestartGame()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(new StartBattleCommand()); 
            gameObject.SetActive(false);
        }
    }
}
