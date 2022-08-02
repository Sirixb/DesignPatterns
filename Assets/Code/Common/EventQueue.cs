using System.Collections.Generic;
using UnityEngine;

namespace Common
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
        }

        private void ProcessEvent(EventData eventData)
        {
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
