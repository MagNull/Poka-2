using System;
using System.Linq;
using Unit_Scripts;
using Unit_Scripts.Unit_State_Machine;
using UnityEngine;
using UnityEngine.AI;

public class BattleStarter : MonoBehaviour
{
    public Action OnBattleStateChange;

    public void StartBattle()
    {
        OnBattleStateChange();
        var units = FindObjectsOfType<UnitStateBehaviour>();
        foreach (var unit in units)
        {
            unit.GetComponent<TargetFindSystem>().enabled = true;
            unit.GetComponent<NavMeshAgent>().enabled = true;
            unit.enabled = true;
            unit.GetComponent<WeaponUser>().enabled = true;
        }
    }
}