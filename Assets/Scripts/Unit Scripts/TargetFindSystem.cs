using System;
using System.Collections.Generic;
using System.Linq;
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
        
        [Inject]
        private UnitsLists _unitsLists;

        private void Awake()
        {
            _unitStateBehaviour = GetComponent<UnitStateBehaviour>();
            _targetFinders = new List<ITargetFinder>()
            {
                new InfantryTargetFinder()
            };
            foreach (var targetFinder in _targetFinders)
            {
                InitTargetFinder(targetFinder);
            }
        }


        public ITargetFinder GetTargetFinder()
        {
            return _unitType switch
            {
                UnitType.INFANTRY => _targetFinders[0]
            };
        }
        
        private void InitTargetFinder(ITargetFinder targetFinder)
        {
            targetFinder.Origin = transform;
            if (_isEnemy)
            {
                _unitsLists.EnemyUnits.Add(_unitStateBehaviour.gameObject);
                targetFinder.Units = _unitsLists.PlayerUnits;
            }
            else
            {
                _unitsLists.PlayerUnits.Add(_unitStateBehaviour.gameObject);
                targetFinder.Units = _unitsLists.EnemyUnits;
            }
        }
    }
}