using System.Collections.Generic;
using Patterns.Adapter;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Facade
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _loadButton;

        [SerializeField] private GameFacade _gameFacade;

        private void Awake()
        {
            _saveButton.onClick.AddListener(SaveGame);
            _loadButton.onClick.AddListener(LoadGame);
        }

        private void SaveGame()
        {
            _gameFacade.SaveGame();
        }

        private void LoadGame()
        {
            _gameFacade.LoadGame();
        }
    }
}
