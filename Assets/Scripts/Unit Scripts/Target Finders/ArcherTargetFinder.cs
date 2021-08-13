using System.Collections.Generic;
using System.Linq;
using Unit_Scripts.Unit_State_Machine;
using UnityEngine;

namespace Unit_Scripts.Target_Finders
{
    public class ArcherTargetFinder : ITargetFinder
    {
        private float _minFindDistance;
        private float _maxFindDistance;
        public IUnitsStateSwitcher StateSwitcher;
        public Transform Origin { get; set; }
        public List<GameObject> Units { get; set; }

        public ArcherTargetFinder(float minFindDistance, float maxFindDistance)
        {
            _minFindDistance = minFindDistance;
            _maxFindDistance = maxFindDistance;
        }

        public Transform GetTarget()
        {
            if (Units.Count == 0) return null;
            var filteredList = Units
                .Select(p => new
                {
                    Unit = p,
                    Distance = (p.transform.position - Origin.transform.position).sqrMagnitude,
                })
                .Where(p => CheckDistance(p.Distance));
            if (!filteredList.Any()) return null;
            
            var unit = filteredList
                .Aggregate((p1, p2) => p1.Distance < p2.Distance ? p1 : p2)
                .Unit.transform;
            
            if ((unit.position - Origin.transform.position).sqrMagnitude >
                _maxFindDistance * _maxFindDistance) StateSwitcher.SwitchState<MovingState>();
            return unit;
        }

        public bool CheckDistance(float distance) =>  distance >= _minFindDistance * _minFindDistance;
    }
}