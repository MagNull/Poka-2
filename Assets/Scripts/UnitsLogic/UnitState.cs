using System;
using UnityEngine;

namespace UnitsLogic
{
    public abstract class UnitState
    {
        protected readonly Func<Transform> _getTarget;
        protected readonly Animator _animator;
        protected readonly IUnitsStateSwitcher _stateSwitcher;
        
        protected UnitState(Func<Transform> getTarget, Animator animator, IUnitsStateSwitcher stateSwitcher)
        {
            _getTarget = getTarget;
            _animator = animator;
            _stateSwitcher = stateSwitcher;
        }
        
        public abstract void Work();

        public abstract void OnEnterState();

        public abstract void OnExitState();

    }
}