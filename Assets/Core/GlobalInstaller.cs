using System.Threading.Tasks;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Core
{
    public class GlobalInstaller : MonoBehaviour
    {
        //private async void Start()
        //{
        //    DontDestroyOnLoad(LoadingScreen.Instance.gameObject);
        //    LoadingScreen.Instance.Show();
        //    await LoadScene("Game");
        //    LoadingScreen.Instance.Hide();
        //}

        //private async Task LoadScene(string sceneName)
        //{
        //    var loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

        //    while (!loadSceneAsync.isDone)
        //    {
        //        await Task.Yield();
        //    }
        //    await Task.Yield();
        //}
    }
}
