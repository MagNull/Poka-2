using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UIControllers;
using UnityEngine;
using Zenject;

namespace Buildings
{
    [RequireComponent(typeof(BuildingPlaceUIController))]
    public class BuildingPlace : MonoBehaviour, IZoomable
    {
        [SerializeField] private GameObject _finishedBuilding;
        [SerializeField] private ParticleSystem _buildingVFX;
        [SerializeField] private Transform _zoomPosition;

        [Header("Price To Build")] 
        [SerializeField] private int _goldToBuild;
        [SerializeField] private int _woodToBuild;
        [SerializeField] private GameObject _neededBuilding;

        [Inject] private PlayerResources _playerResources;
        private AbstractUIController _uiController;
        private bool _isZoomed;
        private CameraZoom _cameraZoom;
        
        public Transform ZoomPosition => _zoomPosition;
        public bool IsZoomed => _isZoomed;

        public GameObject FinishedBuilding => _finishedBuilding;

        public int GoldToBuild => _goldToBuild;

        public int WoodToBuild => _woodToBuild;

        public GameObject NeededBuilding => _neededBuilding;
        

        private void Awake()
        {
            _cameraZoom = Camera.main.GetComponent<CameraZoom>();
            _uiController = GetComponent<AbstractUIController>();
        }

        public void TryToBuild()
        {
            if (CheckPrice() && CheckNeededBuilding())
            {
                TakeResources();
                Build();
            }
        }

        private void TakeResources()
        {
            _playerResources.GoldAmount -= GoldToBuild;
            _playerResources.WoodAmount -= WoodToBuild;
        }

        private void Build()
        {
            FinishedBuilding.SetActive(true);
            FinishedBuilding.transform.parent = null;
            _cameraZoom.Zoom(FinishedBuilding.GetComponent<IZoomable>());
            _buildingVFX.Play();
            Destroy(gameObject);
        }

        private bool CheckPrice()
        {
            return _playerResources.GoldAmount >= GoldToBuild &&
                   _playerResources.WoodAmount >= WoodToBuild;
        }

        private bool CheckNeededBuilding()
        {
            if(!NeededBuilding) return true;
            return NeededBuilding.activeSelf;
        }

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
        
    }
}