using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Unit_Scripts.Unit_State_Machine
{
    public class DyingState : UnitsState
    {
        [Inject] private UnitsLists _unitsLists;
        private int _dieToHash;
        
        public DyingState(Func<Transform> getTarget, Animator animator, 
            IUnitsStateSwitcher stateSwitcher) : 
            base(getTarget, animator, stateSwitcher)
        {
            _dieToHash = Animator.StringToHash("Die");
        }

        public override void Work()
        {
            
        }

        public override void OnEnterState()
        {
            _animator.SetBool(_dieToHash, true);
            _animator.GetComponent<NavMeshAgent>().enabled = false;
        }

        public override void OnExitState()
        {
            
        }
    }
}