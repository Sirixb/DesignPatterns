using Patterns.Decoupling.ServiceLocator;
using System.Threading.Tasks;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Installers
{
    public class GlobalInstaller : MonoBehaviour
    {
        [SerializeField] private Installer[] _installers;
        private async void Start()
        {
            NewMethod();

            await LoadScene("Game");
            ServiceLocator.Instance.GetService<LoadingScreen>().Hide();
        }

        private void NewMethod()
        {
            foreach (var installer in _installers)
            {
                installer.Install(ServiceLocator.Instance);
            }
        }

        private async Task LoadScene(string sceneName)
        {
            var loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!loadSceneAsync.isDone)
            {
                await Task.Yield();
            }
            await Task.Yield();
        }
    }
}
