using System;
using UnityEngine;
using UnityEngine.AI;

namespace Unit_Scripts.Unit_State_Machine
{
    public class IdleState : UnitsState
    {
        private int _idleToHash;
        private NavMeshAgent _navMeshAgent;
        
        public IdleState(Func<Transform> getTarget, Animator animator, IUnitsStateSwitcher stateSwitcher, 
            NavMeshAgent navMeshAgent) : base(getTarget, animator, stateSwitcher)
        {
            _idleToHash = Animator.StringToHash("Idle");
            _navMeshAgent = navMeshAgent;
        }

        public override void Work()
        {
            if(_getTarget.Invoke() != null) _stateSwitcher.SwitchState<MovingState>();
        }

        public override void OnEnterState()
        {
            _navMeshAgent.enabled = false;
            _animator.SetBool(_idleToHash, true);
        }

        public override void OnExitState()
        {
            _navMeshAgent.enabled = true;
            _animator.SetBool(_idleToHash, false);
        }
    }
}