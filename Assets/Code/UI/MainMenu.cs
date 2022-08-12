using System;
using System.Threading.Tasks;
using Common.Commands;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(new LoadSceneCommand("Game").Execute);
        }

        
    }
}
