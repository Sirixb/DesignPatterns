using UnityEngine;

namespace Patterns.Behaviour.State.States
{
    public class IdleState : EnemyState
    {
        private readonly Enemy _context;
        private readonly float _timeToWait;
        private float _currentTime;

        public IdleState(Enemy context, float timeToWait)
        {
            _context = context;
            _timeToWait = timeToWait;
        }

        public void Start()
        {
            _currentTime = 0;
        }

        public bool Update()
        {
            _currentTime += Time.deltaTime;

            return _currentTime >= _timeToWait;
        }

        public void Stop()
        {
        }

        public Enemy.EnemyStates GetNextState()
        {
            return Enemy.EnemyStates.FindTarget;
        }
    }
}
