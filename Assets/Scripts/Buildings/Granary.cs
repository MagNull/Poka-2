using System;
using Interfaces;
using UIControllers;
using UnityEngine;
using Zenject;

namespace Buildings
{
    [RequireComponent(typeof(GranaryUIController))]
    public class Granary : MonoBehaviour, IUpgradeable, IStorage<int>, IZoomable
    {
        [SerializeField] private Transform _zoomTargetTransform;
        private bool _isZoomed;

        [Inject] private PlayerResources _playerResources;
        private AbstractUIController _uiController;

        [SerializeField] private int _maxFoodPerUpgrade;
        
        public Transform ZoomPosition => _zoomTargetTransform;
        public bool IsZoomed => _isZoomed;
        
        public void Zoom()
        {
            _uiController.OpenInterface();
            _isZoomed = true;
        }

        public void Unzoom()
        {
            _uiController.CloseInterface();
            _isZoomed = false;
        }

        public void Upgrade()
        {
            _playerResources.MAXFoodAmount += _maxFoodPerUpgrade;
        }

        private void Awake()
        {
            _uiController = GetComponent<GranaryUIController>();
        }

        private void Start()
        {
            _playerResources.FoodAmount = 0;
            _playerResources.MAXFoodAmount = 10;
        }

        public int Get(int n)
        {
            int returningValue;
            if (n >= _playerResources.FoodAmount)
            {
                returningValue = _playerResources.FoodAmount;
                _playerResources.FoodAmount = 0;
            }
            else
            {
                returningValue = n;
                _playerResources.FoodAmount -= n;
            }

            return returningValue;
        }

        public void Add(int n)
        {
            _playerResources.FoodAmount += n;
            _playerResources.FoodAmount = Mathf.Clamp(_playerResources.FoodAmount, 0, _playerResources.MAXFoodAmount);
        }
    }
}