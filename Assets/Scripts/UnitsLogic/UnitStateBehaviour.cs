using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace UnitsLogic
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class UnitStateBehaviour : MonoBehaviour, IUnitsStateSwitcher
    {
        [SerializeField] private Transform _target;
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        
        private List<UnitState> _states;
        private UnitState _currentState; 
            
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            _states = new List<UnitState>()
            {
                new MovingState(_navMeshAgent, () => { return _target; }, _animator, this, 3),
                new AttackingState(_navMeshAgent, () => { return _target; }, _animator, this)
            };
            _currentState = _states[0];
        }

        private void Update()
        {
            _navMeshAgent.SetDestination(_target.position);
            _currentState.Work();
        }

        public void SwitchState<T>() where T : UnitState
        {
            UnitState state = _states.FirstOrDefault(s => s is T);
            _currentState.OnExitState();
            _currentState = state;
            _currentState.OnEnterState();
        }
    }
}
