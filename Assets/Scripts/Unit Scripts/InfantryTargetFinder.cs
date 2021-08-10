using System.Collections.Generic;
using System.Linq;
using Unit_Scripts.Unit_State_Machine;
using UnityEngine;

namespace Unit_Scripts
{
    public class InfantryTargetFinder : ITargetFinder
    {
        public Transform Origin { get; set; }
        public List<GameObject> Units { get; set; }

        public Transform GetTarget()
        {
            if (Units.Count == 0) return null;
            var unit = Units
                .Select(p => new 
                {
                    Unit = p,
                    Distance = (p.transform.position - Origin.transform.position).sqrMagnitude
                })
                .Aggregate((p1, p2) => p1.Distance < p2.Distance ? p1 : p2)
                .Unit.transform;
            return unit;
        }
    }
}