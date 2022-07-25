namespace Ships.Common
{
    public interface Damageable
    {
        void AddDamage(int amount);
        Teams Team { get; }
    }
}
