using System;
using UnityEngine;
using UnityEngine.AI;

namespace Unit_Scripts.Unit_State_Machine
{
    [Serializable]
    public class MovingState : UnitsState
    {
        [SerializeField] private float _speed = 1;
        private NavMeshAgent _navMeshAgent;
        private int _walkToHash;

        public MovingState(NavMeshAgent navMeshAgent, Func<Transform> getTarget, Animator animator, 
            IUnitsStateSwitcher stateSwitcher, float speed) : 
            base(getTarget, animator, stateSwitcher)
        {
            _navMeshAgent = navMeshAgent;
            _speed = speed;
            _walkToHash = Animator.StringToHash("Walk");
        }
    
        public override void Work()
        {
            _navMeshAgent.speed = _speed;
            Debug.Log(_navMeshAgent.remainingDistance);
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _stateSwitcher.SwitchState<AttackingState>();
            }
        }

        public override void OnEnterState()
        {
            Debug.Log("Start Walk");
            _animator.SetBool(_walkToHash, true);
        }

        public override void OnExitState()
        {
            _animator.SetBool(_walkToHash, false);
        }
    }
}
