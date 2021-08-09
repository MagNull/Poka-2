using System;
using UnityEngine;

namespace Unit_Scripts.Unit_State_Machine
{
    public class DyingState : UnitsState
    {
        private int _dieToHash;
        
        
        public DyingState(Func<Transform> getTarget, Animator animator, IUnitsStateSwitcher stateSwitcher) : base(getTarget, animator, stateSwitcher)
        {
            _dieToHash = Animator.StringToHash("Die");
        }

        public override void Work()
        {
            
        }

        public override void OnEnterState()
        {
            _animator.SetBool(_dieToHash, true);
        }

        public override void OnExitState()
        {
            
        }
    }
}