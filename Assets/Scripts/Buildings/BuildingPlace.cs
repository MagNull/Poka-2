using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Zenject;

namespace Buildings
{
    public class BuildingPlace : MonoBehaviour, IZoomable
    {
        [SerializeField] private GameObject _finishedBuilding;
        [SerializeField] private ParticleSystem _buildingVFX;
        [SerializeField] private Transform _zoomPosition;

        [Header("Price To Build")] 
        [SerializeField] private int _goldToBuild;
        [SerializeField] private int _woodToBuild;

        [Inject] private PlayerResources _playerResources;
        private AbstractInterfaceController _interfaceController;
        private bool _isZoomed;
        private CameraZoom _cameraZoom;

        private void OnMouseDown()
        {
            if (IsZoomed)
            {
                TryToBuild();
            }
        }

        private void Awake()
        {
            _cameraZoom = Camera.main.GetComponent<CameraZoom>();
        }

        private void TryToBuild()
        {
            if (CheckPrice())
            {
                TakeResources();
                Build();
            }
        }

        private void TakeResources()
        {
            _playerResources.GoldAmount -= 2 * _goldToBuild;
            _playerResources.WoodAmount -= _woodToBuild;
        }

        private void Build()
        {
            _finishedBuilding.SetActive(true);
            _finishedBuilding.transform.parent = null;
            _cameraZoom.Zoom(_finishedBuilding.GetComponent<IZoomable>());
            _buildingVFX.Play();
            Destroy(gameObject);
        }

        private bool CheckPrice()
        {
            return _playerResources.GoldAmount >= _goldToBuild &&
                   _playerResources.WoodAmount >= _woodToBuild;
        }

        public Transform ZoomPosition => _zoomPosition;
        public bool IsZoomed => _isZoomed;
        
        public void Zoom()
        {
            //_interfaceController.OpenInterface();
            _isZoomed = true;
        }

        public void Unzoom()
        {
            //_interfaceController.CloseInterface();
            _isZoomed = false;
        }
        
    }
}