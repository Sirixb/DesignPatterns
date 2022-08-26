using Common.Score;
using Patterns.Decoupling.ServiceLocator;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LeaderBoardView : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private RectTransform _container;
        [SerializeField] private ScoreEntryView _scoreEntryViewPrefab;
        private List<ScoreEntryView> _scoreEntryViewInstances;
        private MainMenuMediator _mainMenuMediator;

        public void Configure(MainMenuMediator mainMenuView)
        {
            _mainMenuMediator = mainMenuView;
        }
        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButton);
            _scoreEntryViewInstances = new List<ScoreEntryView>();
        }

        private void OnCloseButton()
        {
            _mainMenuMediator.OnCloseLeaderBoardPressed();
        }

        public void Show()
        {
            //gameObject.SetActive(true);
            var bestScores = ServiceLocator.Instance.GetService<ScoreSystem>().GetBestScores();

            for (int i = 0; i < bestScores.Length; i++)
            {
                int bestScore = bestScores[i];
                if (bestScore == 0)
                {
                    continue;
                }

                var scoreEntryView = Instantiate(_scoreEntryViewPrefab, _container);
                var position = (i + 1).ToString();
                var score = bestScore.ToString();
                scoreEntryView.Configure(position, score);
                _scoreEntryViewInstances.Add(scoreEntryView);
            }
        }
        public void Hide()
        {
            //gameObject.SetActive(false);
            foreach (var scoreEntryView in _scoreEntryViewInstances)
            {
                Destroy(scoreEntryView.gameObject);
            }

            _scoreEntryViewInstances.Clear();
        }
    }
}
