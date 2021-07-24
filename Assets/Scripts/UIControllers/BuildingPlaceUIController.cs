using System;
using Buildings;
using UnityEngine;
using UnityEngine.UI;

namespace UIControllers
{
    [RequireComponent(typeof(BuildingPlace))]
    public class BuildingPlaceUIController : AbstractUIController
    {
        [SerializeField] private Button _buildButton;
        private BuildingPlace _buildingPlace;

        private void Awake()
        {
            _buildingPlace = GetComponent<BuildingPlace>();
        }

        public override void OpenInterface()
        {
            base.OpenInterface();
            ChangeTextsValue();
            _buildButton.gameObject.SetActive(true);
            _buildButton.onClick.AddListener(_buildingPlace.TryToBuild);
        }

        public override void CloseInterface()
        {
            base.CloseInterface();
            _buildButton.gameObject.SetActive(false);
            _buildButton.onClick.RemoveAllListeners();
        }

        public override void ChangeTextsValue()
        {
            _neededLines[0].text = $"To build {_buildingPlace.FinishedBuilding.name} need: ";
            _neededLines[1].text = $"-{_buildingPlace.GoldToBuild} gold";
            _neededLines[2].text = $"-{_buildingPlace.WoodToBuild} wood";
            if (_buildingPlace.NeededBuilding) _neededLines[3].text = $"-{_buildingPlace.NeededBuilding.name}";
            else _neededLines[3].text = "";
        }
    }
}