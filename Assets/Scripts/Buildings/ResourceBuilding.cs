using System;
using Interfaces;
using TMPro;
using UIControllers;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using ITickable = Interfaces.ITickable;

namespace Buildings
{
    [RequireComponent(typeof(ResourceBuildingUIController), typeof(DragOnClick))]
    public class ResourceBuilding : MonoBehaviour, ITickable, IUpgradeable, IZoomable
    {
        [Header("Tick parameters")]
        [SerializeField] private float _tickInterval = 0;
        [SerializeField] private float _minTickInterval = .05f;
        [SerializeField] private float _passiveTickSize = 1;
        [SerializeField] private int _clickTickSize = 1;
        [SerializeField] private ResourcesType _resourcesType;
        private float _timer;
        
        [Header("Upgrade parameters")]
        [SerializeField] private int _upgradeLevel = 1;
        [Space(12)]
        
        [SerializeField] private float _tickIntervalDecreasePerLevel;
        [SerializeField] private int _levelsToUpgradeTickInterval;
        [Space(10)]
        
        [SerializeField] private float _passiveTickIncreasePerLevel;
        [SerializeField] private int _levelsToUpgradePassiveTick;
        [Space(10)]
        
        [SerializeField] private int _clickTickSizeIncreasePerLevel;
        [SerializeField] private int _levelsToUpgradeClickTickSize;
        
        [Space(12)]
        [SerializeField] private int _woodCostUpgrade;
        [SerializeField] private int _woodCostIncrease;
        [SerializeField] private int _goldCostUpgrade;
        [SerializeField] private int _goldCostIncrease;
        
        [Inject] private PlayerResources _playerResources;
        [SerializeField] private Transform _zoomTargetTransform;
        private bool _isZoomed;

        private DragOnClick _dragOnClick;
        private string _resourceName;
        private AbstractUIController _uiController;

        public string ResourceName => _resourceName;

        public float TickInterval => _tickInterval;

        public float PassiveTickSize => _passiveTickSize;

        public int ClickTickSize => _clickTickSize;

        public Transform ZoomPosition
        {
            get => _zoomTargetTransform;
        }

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

        public virtual void Tick(float tickSize)
        {
            switch (_resourcesType)
            {
                case ResourcesType.GOLD:
                    _playerResources.GoldAmount += tickSize;
                    break;
                case ResourcesType.WOOD:
                    _playerResources.WoodAmount += tickSize;
                    break;
                case ResourcesType.HUMANS:
                    _playerResources.HumansAmount += tickSize;
                    break;
            }
        }

        public void Upgrade()
        {
            if (CheckResourcesCost())
            {
                TakeResources();
                _tickInterval -= _upgradeLevel % _levelsToUpgradeTickInterval == 0 ? _tickIntervalDecreasePerLevel : 0;
                _tickInterval = Mathf.Clamp(_tickInterval, _minTickInterval, float.MaxValue);
                _tickInterval = (float)Math.Round(_tickInterval, 1);
            
                _passiveTickSize += _upgradeLevel % _levelsToUpgradePassiveTick == 0 ? _passiveTickIncreasePerLevel : 0;
                _passiveTickSize = (float)Math.Round(_passiveTickSize, 1);
            
                _clickTickSize += _upgradeLevel % _levelsToUpgradeClickTickSize == 0 ? _clickTickSizeIncreasePerLevel : 0;
            
                _upgradeLevel++;
            }
            else
            {
                Debug.Log("Not enough resources.");
            }
        }

        private bool CheckResourcesCost()
        {
            return _playerResources.WoodAmount >= _woodCostUpgrade && 
                   _playerResources.GoldAmount >= _goldCostUpgrade;
        }

        private void TakeResources()
        {
            _playerResources.WoodAmount -= _woodCostUpgrade;
            _woodCostUpgrade += _woodCostIncrease;

            _playerResources.GoldAmount -= _goldCostUpgrade;
            _goldCostUpgrade += _goldCostIncrease;
        }
        protected void Awake()
        {
            _uiController = GetComponent<ResourceBuildingUIController>();
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