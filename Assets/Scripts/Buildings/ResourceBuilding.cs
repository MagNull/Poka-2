using System;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using ITickable = Interfaces.ITickable;

namespace Buildings
{
    [RequireComponent(typeof(ResourceBuildingInterfaceController), typeof(DragOnClick))]
    public class ResourceBuilding : MonoBehaviour, ITickable, IUpgradeable, IZoomable
    {
        [SerializeField] private float _tickInterval = 0;
        [SerializeField] private int _passiveTickSize = 1;
        [SerializeField] private int _clickTickSize = 1;
        [SerializeField] private float _timer;
        [SerializeField] private ResourcesType _resourcesType;

        
        [Inject] private PlayerResources _playerResources;
        [SerializeField] private Transform _zoomTargetTransform;
        private bool _isZoomed;

        private DragOnClick _dragOnClick;
        private string _resourceName;
        private ResourceBuildingInterfaceController _interfaceController;

        public string ResourceName => _resourceName;

        public float TickInterval => _tickInterval;

        public int PassiveTickSize => _passiveTickSize;

        public int ClickTickSize => _clickTickSize;

        public Transform ZoomPosition
        {
            get => _zoomTargetTransform;
        }

        public bool IsZoomed => _isZoomed;
        
        public void Zoom()
        {
            _interfaceController.OpenInterface();
            _isZoomed = true;
        }

        public void Unzoom()
        {
            _interfaceController.CloseInterface();
            _isZoomed = false;
        }

        public virtual void Tick(int tickSize)
        {
            switch (_resourcesType)
            {
                case ResourcesType.GOLD:
                    _playerResources.GoldAmount += PassiveTickSize;
                    break;
                case ResourcesType.WOOD:
                    _playerResources.WoodAmount += PassiveTickSize;
                    break;
                case ResourcesType.HUMANS:
                    _playerResources.HumansAmount += PassiveTickSize;
                    break;
            }
        }

        public void Upgrade()
        {
            Debug.Log("Upgrade");
        }

        protected void Awake()
        {
            _interfaceController = GetComponent<ResourceBuildingInterfaceController>();
            _dragOnClick = GetComponent<DragOnClick>();
        }

        protected virtual void Start()
        {
            InitResourceName();
            switch (_resourcesType)
            {
                case ResourcesType.GOLD:
                    _playerResources.GoldAmount = 0;
                    break;
                case ResourcesType.WOOD:
                    _playerResources.WoodAmount = 0;
                    break;
                case ResourcesType.HUMANS:
                    _playerResources.HumansAmount = 0;
                    break;
            }
        }

        private void InitResourceName()
        {
            _resourceName = _resourcesType.ToString().ToLower();
            _resourceName = ResourceName.Substring(0, 1).ToUpper() +
                            (ResourceName.Length > 1 ? ResourceName.Substring(1) : "");
        }

        private void Update()
        {
            if (_timer >= TickInterval && TickInterval != 0)
            {
                Tick(PassiveTickSize);
                _timer = 0;
            }
            else
            {
                _timer += Time.deltaTime;
            }
        }
        
        private void OnMouseDown()
        {
            if (IsZoomed && !EventSystem.current.IsPointerOverGameObject())
            {
                Tick(ClickTickSize);
                _dragOnClick.Shrink();
            }
        }
        
    }
}