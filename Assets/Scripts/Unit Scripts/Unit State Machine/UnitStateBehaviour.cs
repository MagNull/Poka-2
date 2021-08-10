using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Unit_Scripts.Unit_State_Machine
{
    [RequireComponent(typeof(NavMeshAgent), typeof(TargetFindSystem))]
    public class UnitStateBehaviour : MonoBehaviour, IUnitsStateSwitcher
    {
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        
        private List<UnitsState> _states;
        private UnitsState _currentState;

        private TargetFindSystem _targetFindSystem;
        private ITargetFinder _targetFinder;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _targetFindSystem = GetComponent<TargetFindSystem>();
        }

        private void Start()
        {
            _targetFinder = _targetFindSystem.GetTargetFinder();
            InitStates();
        }

        private void InitStates()
        {
            _states = new List<UnitsState>()
            {
                new IdleState(() => _targetFinder.GetTarget(), _animator, this),
                new MovingState(_navMeshAgent, () => _targetFinder.GetTarget(), _animator, this, 3),
                new AttackingState(_navMeshAgent, () => _targetFinder.GetTarget(), _animator, this),
                new DyingState(() => _targetFinder.GetTarget(), _animator, this)
            };
            _currentState = _states[0];
            _currentState.OnEnterState();
        }

        private void Update()
        {
            _currentState.Work();
        }

        public void SwitchState<T>() where T : UnitsState
        {
            UnitsState state = _states.FirstOrDefault(s => s is T);
            _currentState.OnExitState();
            _currentState = state;
            _currentState.OnEnterState();
        }
    }
}
