namespace Patterns.Behaviour.State.States
{
    public interface EnemyState
    {
        void Start();
        bool Update();
        void Stop();
        Enemy.EnemyStates GetNextState();
    }
}
