namespace Patterns.Decoupling.EventQueueWithObserver
{
    public interface EventObserver
    {
        void Process(EventData eventData);
    }
}