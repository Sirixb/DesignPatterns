using System;
using UnityEngine;

namespace Patterns.Decoupling.ServiceLocator
{
    public class Consumer : MonoBehaviour
    {
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
            {
                var scoreSystem = ServiceLocator.Instance.GetService<IScoreSystem>();
                scoreSystem.AddScore(100);
                ServiceLocator.Instance.GetService<IScoreSystem>().AddScore(100);
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
            {
                var scoreSystem = ServiceLocator.Instance.GetService<IScoreSystem>();
                scoreSystem.AddScore(100);
                ServiceLocator.Instance.GetService<IScoreSystem>().AddScore(100);
            }
        }
    }
}
