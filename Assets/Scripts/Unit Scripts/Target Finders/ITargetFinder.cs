using System.Collections.Generic;
using UnityEngine;

namespace Unit_Scripts.Target_Finders
{
    public interface ITargetFinder
    {
        public Transform Origin { get; set; }
        public List<GameObject> Units { get; set; }
        public Transform GetTarget();
    }
}