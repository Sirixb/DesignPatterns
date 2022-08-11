using UnityEngine;

namespace Patterns.Decoupling.ServiceLocator
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private ScoreSystemMonoBehaviour2 _scoreSystemMonoBehaviour2;
        private void Awake()
        {
            //ServiceLocator.Instance.RegisterService<IScoreSystem>(new ScoreSystem());
            ServiceLocator.Instance.RegisterService<IScoreSystem>(_scoreSystemMonoBehaviour2);
        }
    }
}
