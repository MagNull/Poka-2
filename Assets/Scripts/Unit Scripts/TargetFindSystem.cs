using System;
using System.Collections.Generic;
using System.Linq;
using Unit_Scripts.Target_Finders;
using Unit_Scripts.Unit_State_Machine;
using UnityEngine;
using Zenject;

namespace Unit_Scripts
{
    [RequireComponent(typeof(UnitStateBehaviour))]
    public class TargetFindSystem : MonoBehaviour
    {       
        [SerializeField] private bool _isEnemy;
        [SerializeField] private UnitType _unitType;
        private UnitStateBehaviour _unitStateBehaviour;
        private List<ITargetFinder> _targetFinders;
        
        private UnitsLists _unitsLists;
        
        [Space, Header("Options for archer target finder")]
        [SerializeField] private float _minFindDistance;
        [SerializeField] private float _maxFindDistance;
        
        [Inject]
        public void Construct(UnitsLists unitsLists)
        {
            _unitsLists = unitsLists;
        }
        
        public void Start()
        {
            _unitStateBehaviour = GetComponent<UnitStateBehaviour>();
            _targetFinders = new List<ITargetFinder>()
            {
                new InfantryTargetFinder(),
                new ArcherTargetFinder(_minFindDistance,_maxFindDistance)
            };
            ((ArcherTargetFinder) _targetFinders[1]).StateSwitcher = GetComponent<IUnitsStateSwitcher>();
            foreach (var targetFinder in _targetFinders)
            {
                InitTargetFinder(targetFinder);
            }

            InitUnitsLists();
        }


        public ITargetFinder GetTargetFinder()
        {
            return _unitType switch
            {
                UnitType.INFANTRY => _targetFinders[0],
                UnitType.ARCHER => _targetFinders[1]
            };
        }

        private void InitUnitsLists()
        {
            if (_isEnemy)
            {
                _unitsLists.EnemyUnits.Add(_unitStateBehaviour.gameObject);
            }
            else
            {
                _unitsLists.PlayerUnits.Add(_unitStateBehaviour.gameObject);
            }
        }
        
        private void InitTargetFinder(ITargetFinder targetFinder)
        {
            targetFinder.Origin = transform;
            if (_isEnemy)
            {
                targetFinder.Units = _unitsLists.PlayerUnits;
            }
            else
            {
                targetFinder.Units = _unitsLists.EnemyUnits;
            }
        }
    }
}