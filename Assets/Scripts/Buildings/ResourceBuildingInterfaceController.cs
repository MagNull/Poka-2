using System;
using DG.Tweening;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Buildings
{
    [RequireComponent(typeof(ResourceBuilding))]
    public class ResourceBuildingInterfaceController : AbstractInterfaceController
    {
        [SerializeField] protected Button _upgradeButton;
        private ResourceBuilding _resourceBuilding;

        private void Awake()
        {
            _resourceBuilding = GetComponent<ResourceBuilding>();
        }

        private void Update()
        {
            if (_resourceBuilding.IsZoomed)
            {
                ChangeTextsValue();
            }
        }

        public override void OpenInterface()
        {
            base.OpenInterface();
            _upgradeButton.onClick.AddListener(_resourceBuilding.Upgrade);
        }
        
        public override void CloseInterface()
        {
            base.CloseInterface();
            
            _upgradeButton.onClick.RemoveListener(_resourceBuilding.Upgrade);
        }

        public override void ChangeTextsValue()
        {
            _neededLines[0].text = $"{_resourceBuilding.ResourceName} per click = " +
                                         _resourceBuilding.ClickTickSize;
            _neededLines[1].text = $"Passive {_resourceBuilding.ResourceName.ToLower()} gain = " + 
                                   _resourceBuilding.PassiveTickSize;
            _neededLines[2].text = "Passive gain interval = " + _resourceBuilding.TickInterval; 
        }
    }
}