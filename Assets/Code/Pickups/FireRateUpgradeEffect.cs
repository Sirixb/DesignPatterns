using Ships;

namespace Pickups
{
    public class FireRateUpgradeEffect : PickupEffect
    {
        private readonly float _fireRateMultiplier;

        public FireRateUpgradeEffect(float fireRateMultiplier)
        {
            _fireRateMultiplier = fireRateMultiplier;
        }

        public void Apply(ShipMediator ship)
        {
            ship.MultiplyFireRate(_fireRateMultiplier);
        }
    }
}
