using UnityEngine;

namespace Patterns.Decoupling.EventQueueWithObserver
{
    public class Installer : MonoBehaviour
    {
        private void Start()
        {
            new ScoreSystem();
            new AchievementsSystem();
        }
    }
}