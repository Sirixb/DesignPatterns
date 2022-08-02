
namespace Common
{
    public interface EventObserver
    {
        void Process(EventData eventData);
    }
}