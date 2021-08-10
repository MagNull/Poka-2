using System.Collections.Generic;
using Unit_Scripts.Unit_State_Machine;
using UnityEngine;

namespace Unit_Scripts
{
    public class UnitsLists //Think about divide units by type into different lists
    {
        public List<GameObject> PlayerUnits = new List<GameObject>();
        public List<GameObject> EnemyUnits = new List<GameObject>();
    }
}