using UnityEngine;

namespace Patterns.Decoupling.EventQueueWithObserver
{
    public class ScoreSystem : EventObserver
    {
        public ScoreSystem()
        {
            EventQueue.Instance.Subscribe(EventIds.EnemyDeath, this);
            EventQueue.Instance.Subscribe(EventIds.EnemyDeath, this);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId != EventIds.EnemyDeath)
            {
                return;
            }

            var enemyDeathEventData = (EnemyDeathEventData) eventData;
            Debug.Log("Score added " + enemyDeathEventData.ScoreToAdd);
        }
    }
}
