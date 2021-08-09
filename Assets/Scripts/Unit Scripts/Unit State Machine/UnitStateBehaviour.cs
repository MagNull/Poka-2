using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Unit_Scripts.Unit_State_Machine
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class UnitStateBehaviour : MonoBehaviour, IUnitsStateSwitcher
    {
        [SerializeField] private Transform _target;
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        
        private List<UnitsState> _states;
        private UnitsState _currentState; 
            
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _states = new List<UnitsState>()
            {
                new MovingState(_navMeshAgent, () => { return _target; }, _animator, this, 3),
                new AttackingState(_navMeshAgent, () => { return _target; }, _animator, this),
                new DyingState( () => { return _target; }, _animator, this)
            };
            _currentState = _states[0];
            _currentState.OnEnterState();
        }

        private void Update()
        {
            _navMeshAgent.SetDestination(_target.position);
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
