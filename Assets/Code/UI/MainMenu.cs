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
            //Solucion profe, yo la hice directamente en el LoadGameSceneCommand
            /*var compositeCommand = new CompositeCommand();
            compositeCommand.AddCommand(new LoadSceneCommand("Game"));
            compositeCommand.AddCommand(new StartBattleCommand());*/
            
            ServiceLocator.Instance.GetService<CommandQueue>()
                         .AddCommand(/*compositeCommand*/ new LoadGameSceneCommand());

        }

        
    }
}
