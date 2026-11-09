using Common;

namespace Pickups
{
    // Observer: drops a pickup where a ship configured to drop one was destroyed,
    // and clears the remaining pickups when the battle ends or restarts.
    public class PickupDropper : EventObserver
    {
        private readonly PickupFactory _pickupFactory;

        public PickupDropper(PickupFactory pickupFactory)
        {
            _pickupFactory = pickupFactory;
        }

        public void Subscribe(EventQueue eventQueue)
        {
            eventQueue.Subscribe(EventIds.ShipDestroyed, this);
            eventQueue.Subscribe(EventIds.GameOver, this);
            eventQueue.Subscribe(EventIds.Victory, this);
            eventQueue.Subscribe(EventIds.Restart, this);
        }

        public void Unsubscribe(EventQueue eventQueue)
        {
            eventQueue.Unsubscribe(EventIds.ShipDestroyed, this);
            eventQueue.Unsubscribe(EventIds.GameOver, this);
            eventQueue.Unsubscribe(EventIds.Victory, this);
            eventQueue.Unsubscribe(EventIds.Restart, this);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ShipDestroyed)
            {
                var shipDestroyed = (ShipDestroyedEventData) eventData;
                if (shipDestroyed.Drop != PickupIds.None)
                {
                    _pickupFactory.Create(shipDestroyed.Drop, shipDestroyed.Position);
                }

                return;
            }

            _pickupFactory.RecycleAll();
        }
    }
}
