namespace Ships
{
    public interface Ship 
    {
        string Id { get; }
        void OnDamageReceived(bool isDeath);
    }
}
