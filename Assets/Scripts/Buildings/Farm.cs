using System;
using DG.Tweening;
using Interfaces;
using UnityEngine;

namespace Buildings
{
    public class Farm : ResourceBuilding
    {
        [SerializeField] private Granary _granary;
        public override void Tick(int tickSize)
        {
            if(_granary.gameObject.activeSelf)_granary.Add(tickSize);
        }
    }
}