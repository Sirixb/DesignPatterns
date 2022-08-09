using System;
using System.Collections.Generic;
using Patterns.Behaviour.State.States;
using UnityEngine;

namespace Patterns.Behaviour.State
{
    public class Enemy : MonoBehaviour
    {
        public enum EnemyStates
        {
            Idle,
            FindTarget,
            MoveToTarget,
            Attack
        }

        [SerializeField] private float _idleTime = 2f;
        [SerializeField] private float _visionRange = 20f;

        [SerializeField] private float _minDistanceToAttack = 2f;
        [SerializeField] private float _movementSpeed = 2f;
        [SerializeField] private int _attackDamage = 2;
        private EnemyState _currentState;
        public Enemy EnemyToAttack { get; internal set; }

        private Dictionary<EnemyStates, EnemyState> _idToState;

        private void Awake()
        {
            _idToState =
                new Dictionary<EnemyStates, EnemyState>
                {
                    {EnemyStates.Idle, new IdleState(this, _idleTime)},
                    {EnemyStates.FindTarget, new FindTargetState(this, _visionRange, new TargetFinderStrategy())},
                    {EnemyStates.MoveToTarget, new MoveToTargetState(this, _minDistanceToAttack, _movementSpeed)},
                    {EnemyStates.Attack, new AttackToTargetState(this, _attackDamage)}
                };
        }

        private void Start()
        {
            _currentState = GetState(EnemyStates.Idle);
            _currentState.Start();
        }

        private void Update()
        {
            if (_currentState.Update())
            {
                NextState();
            }
        }

        private void NextState()
        {
            _currentState.Stop();
            _currentState = GetState(_currentState.GetNextState());
            _currentState.Start();
        }

        private EnemyState GetState(EnemyStates state)
        {
            return _idToState[state];
        }

        public void DoDamage(float damageToApply)
        {
            Debug.Log($"receive damage: {name}");
        }
    }
}
