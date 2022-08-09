using UnityEngine;

namespace Patterns.Behaviour.State.States
{
    public class MoveToTargetState : EnemyState
    {
        private readonly Enemy _context;
        private readonly float _movementSpeed;
        private readonly float _sqrMinDistanceToAttack;

        public MoveToTargetState(Enemy context, float minDistanceToAttack, float movementSpeed)
        {
            _context = context;
            _movementSpeed = movementSpeed;
            _sqrMinDistanceToAttack = minDistanceToAttack * minDistanceToAttack;
        }

        public void Start()
        {
        }

        public bool Update()
        {
            var target = _context.EnemyToAttack;
            if (target == null)
            {
                return true;
            }

            var distanceToTheTarget = target.transform.position - _context.transform.position;
            if (distanceToTheTarget.sqrMagnitude > _sqrMinDistanceToAttack)
            {
                _context.transform.Translate(distanceToTheTarget.normalized * (_movementSpeed * Time.deltaTime));
            }

            return distanceToTheTarget.sqrMagnitude <= _sqrMinDistanceToAttack;
        }

        public void Stop()
        {
        }

        public Enemy.EnemyStates GetNextState()
        {
            return _context.EnemyToAttack != null ? Enemy.EnemyStates.Attack : Enemy.EnemyStates.Idle;
        }
    }
}
