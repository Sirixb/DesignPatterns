using UnityEngine;

namespace Patterns.Decoupling.EventQueue
{
    public class AchievementsSystem
    {
        public static AchievementsSystem Instance => _instance ?? (_instance = new AchievementsSystem());
        private static AchievementsSystem _instance;

        private int _numberOfEnemiesDead;

        private AchievementsSystem()
        {
            _numberOfEnemiesDead = 0;
        }
        
        public void EnemyDeath()
        {
            Debug.Log("Enemy Death");
            _numberOfEnemiesDead += 1;

            if (_numberOfEnemiesDead == 3)
            {
                var eventData = new EventData(EventIds.AchievementUnlocked);
                EventQueue.Instance.EnqueueEvent(eventData);
            }
        }
    }
}
