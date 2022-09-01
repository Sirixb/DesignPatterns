using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoadingScreen : MonoBehaviour 
    {
        [SerializeField] private Image _screenFadeImage;

        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }

    }
}
