using System;
using UnitsLogic;
using UnityEngine;
using UnityEngine.AI;

public class AttackingState : UnitState
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
        Debug.Log(_navMeshAgent.remainingDistance);
        if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
        {
            _stateSwitcher.SwitchState<MovingState>();
        }
    }

    public override void OnEnterState()
    {
        _animator.SetBool(_attackToHash, true);
    }

    public override void OnExitState()
    {
        _animator.SetBool(_attackToHash, false);
    }
}