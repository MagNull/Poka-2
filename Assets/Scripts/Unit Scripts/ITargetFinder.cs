using System.Collections.Generic;
using Unit_Scripts.Unit_State_Machine;
using UnityEngine;

namespace Unit_Scripts
{
    public interface ITargetFinder
    {
        public Transform Origin { get; set; }
        public List<GameObject> Units { get; set; }
        public Transform GetTarget();
    }
}