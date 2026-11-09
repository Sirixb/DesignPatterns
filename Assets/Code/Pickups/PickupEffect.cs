using Ships;

namespace Pickups
{
    // Strategy: what a pickup does to the ship that collects it.
    public interface PickupEffect
    {
        void Apply(ShipMediator ship);
    }
}
