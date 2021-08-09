using System;
using UnityEngine;
using UnityEngine.AI;

namespace Unit_Scripts.Unit_State_Machine
{
    public class AttackingState : UnitsState
    {
        private int _attackToHash;
        private NavMeshAgent _navMeshAgent;
    
        public AttackingState(NavMeshAgent navMeshAgent, Func<Transform> getTarget, Animator animator, 
            IUnitsStateSwitcher stateSwitcher) : 
            base(getTarget, animator, stateSwitcher)
        {
            _navMeshAgent = navMeshAgent;
            _attackToHash = Animator.StringToHash("Attack");
        }

        public override void Work()
        {
            if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
            {
                _stateSwitcher.SwitchState<MovingState>();
            }
        }

        public override void OnEnterState()
        {
            _animator.SetBool(_attackToHash, true);
            _navMeshAgent.transform.LookAt(_getTarget.Invoke().transform.position);
        }

        public override void OnExitState()
        {
            _animator.SetBool(_attackToHash, false);
        }
    }
}