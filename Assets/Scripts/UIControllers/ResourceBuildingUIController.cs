using Buildings;
using UnityEngine;
using UnityEngine.UI;

namespace UIControllers
{
    [RequireComponent(typeof(ResourceBuilding))]
    public class ResourceBuildingUIController : AbstractUIController
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
            _upgradeButton.gameObject.SetActive(true);
            _upgradeButton.onClick.AddListener(_resourceBuilding.Upgrade);
        }
        
        public override void CloseInterface()
        {
            base.CloseInterface();
            _upgradeButton.gameObject.SetActive(false);
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