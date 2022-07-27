using UnityEngine;

namespace Patterns.Decoupling.EventQueueWithObserver
{
    public class AchievementsSystem : EventObserver
    {
        private int _numberOfEnemiesDead;

        public AchievementsSystem()
        {
            _numberOfEnemiesDead = 0;
            EventQueue.Instance.Subscribe(EventIds.EnemyDeath, this);
        }
        
        public void Process(EventData eventData)
        {
            if (eventData.EventId != EventIds.EnemyDeath)
            {
                return;
            }
            
            Debug.Log("Enemy Death");
            _numberOfEnemiesDead += 1;

            if (_numberOfEnemiesDead == 3)
            {
                var newEventData = new EventData(EventIds.AchievementUnlocked);
                EventQueue.Instance.EnqueueEvent(newEventData);
            }
        }
    }
}
