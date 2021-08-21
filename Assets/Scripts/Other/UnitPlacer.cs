using System;
using System;
using Unit_Scripts;
using Unit_Scripts;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.EventSystems;

public class UnitPlacer : MonoBehaviour
{
    [SerializeField] private BattleStarter _battleStarter;
    private UnitPlacement _currentUnit;
    private UnitPlacement _currentUnitPrefab;
    private Camera _camera;
    private bool _isBattleStart = false;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        _battleStarter.OnBattleStateChange += () =>
        {
            if(_currentUnit)Destroy(_currentUnit.gameObject);
            _isBattleStart = !_isBattleStart;
        };
    }

    public void SetUnit(UnitPlacement unit)
    {
        if (!_isBattleStart)
        {
            if (!(_currentUnit is null))
            {
                Destroy(_currentUnit.gameObject);
            }
            _currentUnit = Instantiate(unit, new Vector3(999,999,999), Quaternion.identity);
            _currentUnitPrefab = unit;
        }
    }

    private void Update()
    {
        if (!(_currentUnit is null) && !_isBattleStart)
        {
            MoveUnit();
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                PlaceUnit();
            } 
        }
    }

    private void PlaceUnit()
    {
        if (_currentUnit.Place())
        {
            _currentUnit = Instantiate(_currentUnitPrefab, _currentUnit.transform.position, Quaternion.identity);
        }
    }

    private void MoveUnit()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, int.MaxValue, 1))
        {
            _currentUnit.transform.position = hit.point;
        }
    }
}