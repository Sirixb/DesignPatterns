using Common.Commands;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;

        private void Start()
        {
            _startGameButton.onClick.AddListener(OnStartButtonPressed);
        }

        public void OnStartButtonPressed()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                         .AddCommand(new LoadGameSceneCommand());
        }

        
    }
}
