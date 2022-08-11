using Ships;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ships.Common;
using Common;
using Battle;
using Patterns.Decoupling.ServiceLocator;

namespace UI
{
    public class GameOverView : MonoBehaviour, EventObserver
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameFacade _gameFacade;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
        }

        private void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.GameOver, this);
            gameObject.SetActive(false);
        }
        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.GameOver, this);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.GameOver)
            {
                _scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
                gameObject.SetActive(true);
            }
        }

        private void RestartGame()
        {
            _gameFacade.StartBattle();
            gameObject.SetActive(false);
        }


    }
}
