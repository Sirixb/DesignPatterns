using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Decoupling.EventQueueWithObserver
{
    public class EventQueue : MonoBehaviour
    {
        public static EventQueue Instance { get; private set; }

        private Queue<EventData> _currentEvents;
        private Queue<EventData> _nextEvents;

        private Dictionary<EventIds, List<EventObserver>> _observers;

        private void Awake()
        {
            Instance = this;

            _currentEvents = new Queue<EventData>();
            _nextEvents = new Queue<EventData>();
            _observers = new Dictionary<EventIds, List<EventObserver>>();
        }

        public void Subscribe(EventIds eventId, EventObserver eventObserver)
        {
            if (!_observers.TryGetValue(eventId, out var eventObservers))
            {
                eventObservers = new List<EventObserver>();
            }

            eventObservers.Add(eventObserver);
            _observers[eventId] = eventObservers;
        }

        public void Unsubscribe(EventIds eventId, EventObserver eventObserver)
        {
            _observers[eventId].Remove(eventObserver);
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

        private void ProcessEvent(EventData eventData)
        {
            Debug.Log($"Processing event {eventData.EventId} on frame {Time.frameCount}");

            if (_observers.TryGetValue(eventData.EventId, out var eventObservers))
            {
                foreach (var eventObserver in eventObservers)
                {
                    eventObserver.Process(eventData);
                }
            }
        }
    }
}
