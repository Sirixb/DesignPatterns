namespace Patterns.Decoupling.EventQueueWithObserver
{
    public class EventData
    {
        public readonly EventIds EventId;

        public EventData(EventIds eventId)
        {
            EventId = eventId;
        }
    }
}
