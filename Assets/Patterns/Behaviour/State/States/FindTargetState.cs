namespace Patterns.Behaviour.State.States
{
    public class FindTargetState : EnemyState
    {
        private readonly Enemy _context;
        private readonly float _visionRange;
        private readonly float _sqrMaxDistance;
        private readonly TargetFinder _targetFinder;
        private bool _enemyFound;

        public FindTargetState(Enemy context, float visionRange, TargetFinder targetFinder)
        {
            _context = context;
            _visionRange = visionRange;
            _targetFinder = targetFinder;
            _sqrMaxDistance = visionRange * visionRange;
        }

        public void Start()
        {
            _enemyFound = false;
        }

        public bool Update()
        {
            var targets = _targetFinder.FindTargets();
            foreach (var target in targets)
            {
                if (target == _context)
                {
                    continue;
                }

                var sqrDistanceToTheTarget = (target.transform.position - _context.transform.position).sqrMagnitude;
                if (sqrDistanceToTheTarget > _sqrMaxDistance)
                {
                    continue;
                }

                _enemyFound = true;
                _context.EnemyToAttack = target;
            }

            return true;
        }

        public void Stop()
        {
        }

        public Enemy.EnemyStates GetNextState()
        {
            return _enemyFound ? Enemy.EnemyStates.MoveToTarget : Enemy.EnemyStates.Idle;
        }
    }
}
