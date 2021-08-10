using System;
using UnityEngine;

namespace Unit_Scripts.Unit_State_Machine
{
    public class IdleState : UnitsState
    {
        private int _idleToHash;
        
        public IdleState(Func<Transform> getTarget, Animator animator, IUnitsStateSwitcher stateSwitcher) : base(getTarget, animator, stateSwitcher)
        {
            _idleToHash = Animator.StringToHash("Idle");
        }

        public override void Work()
        {
            if(_getTarget.Invoke() != null) _stateSwitcher.SwitchState<MovingState>();
        }

        public override void OnEnterState()
        {
            _animator.SetBool(_idleToHash, true);
        }

        public override void OnExitState()
        {
            _animator.SetBool(_idleToHash, false);
        }
    }
}