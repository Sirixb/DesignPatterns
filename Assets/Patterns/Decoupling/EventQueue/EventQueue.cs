using System;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Decoupling.EventQueue
{
    public class EventQueue : MonoBehaviour
    {
        public static EventQueue Instance { get; private set; }
        
        private Queue<EventData> _currentEvents;
        private Queue<EventData> _nextEvents;

        private void Awake()
        {
            Instance = this;
            
            _currentEvents = new Queue<EventData>();
            _nextEvents = new Queue<EventData>();
        }

        public void EnqueueEvent(EventData eventData)
        {
            _nextEvents.Enqueue(eventData);
            Debug.Log($"Enqueued event {eventData.EventId} on frame {Time.frameCount}");
        }
        private void LateUpdate()
        {
            ProcessEvents();
        }

        private void ProcessEvents()
        {
            var tempCurrentEvents = _currentEvents;
            _currentEvents = _nextEvents;
            _nextEvents = tempCurrentEvents;

            foreach (var currentEvent in _currentEvents)
            {
                ProcessEvent(currentEvent);
            }

            _currentEvents.Clear();

            /*if (_nextEvents.Count > 0)
            {
                ProcessEvents();
            }*/
        }

        private static void ProcessEvent(EventData eventData)
        {
            Debug.Log($"Processing event {eventData.EventId} on frame {Time.frameCount}");
            switch (eventData.EventId)
            {
                case EventIds.EnemyDeath:
                    var enemyDeathEventData = (EnemyDeathEventData)eventData;
                    AchievementsSystem.Instance.EnemyDeath();
                    ScoreSystem.Instance.AddScore(enemyDeathEventData.ScoreToAdd);
                    break;
                case EventIds.AchievementUnlocked:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
